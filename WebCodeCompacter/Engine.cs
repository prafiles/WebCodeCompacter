using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WebCodeCompacter
{
    public partial class MainWindow
    {
        private Stream myStream = null;
        private int Byte;
        private char Character;
        //private char PreviousCharacter = ' ';
        private long TotalByteCounter;
        private long OutputByteCounter;
        private bool EOFFlag;
        private string Line;
        private void processFile()
        {
            string fileName;
            string fileExtension;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.CurrentDirectory;
            openFileDialog.Filter = "HTM files (*.htm)|*.htm|HTML files (*.html)|*.html|CSS files (*.css)|*.css|JavaScript files (*.js)|*.js|ASPX files (*.aspx)|*.aspx|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 6;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = openFileDialog.OpenFile()) != null)
                {
                    fileName = openFileDialog.FileName;
                    txt_FileName.Text = fileName;
                    fileExtension = fileName.Substring(fileName.Length - 4, 4);
                    try
                    {
                        if (fileExtension == ".CSS" || fileExtension == ".css")
                        {
                            Thread workerThread = new Thread(workerThreadFunctionCSS);
                            workerThread.Start();
                        }
                        else if (fileExtension.Substring(1) == ".JS" || fileExtension.Substring(1) == ".js")
                        {
                            Thread workerThread = new Thread(workerThreadFunctionJS);
                            workerThread.Start();
                        }
                        else if (fileExtension == ".HTM" || fileExtension == ".htm" || fileExtension == "HTML" || fileExtension == "html" || fileExtension == "ASPX" || fileExtension == "aspx")
                        {
                            Thread workerThread = new Thread(workerThreadFunctionHTML);
                            workerThread.Start();
                        }
                        else
                        {
                            MessageBox.Show("Please select a proper file type");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Could not read file from disk. Error Details : " + Environment.NewLine + ex.Message);
                    }
                }
            }
        }
        private void workerThreadFunctionCSS()
        {
            Line = "";
            TotalByteCounter = 0;
            OutputByteCounter = 0;
            EOFFlag = false;
            long fileSize = myStream.Length;
            long progressBarStep = fileSize / 100;
            using (myStream)
            {
                Byte = myStream.ReadByte();
                Byte = myStream.ReadByte();
                Byte = myStream.ReadByte();
                Byte = myStream.ReadByte();
                if (Byte != -1)
                {
                    Character = char.ConvertFromUtf32(Byte).ToCharArray()[0];
                    TotalByteCounter++;
                }
                while (Byte != -1)
                {
                    if (isWhiteSpace(Character) && EOFFlag != true)
                    {
                        getChar();
                    }
                    if (isPunctuation(Character))
                    {
                        appendLine(Character);
                        getChar();
                    }
                    if (!isWhiteSpace(Character) && !isPunctuation(Character))
                    {
                        appendLine(Character);
                        while (!isWhiteSpace(Character) && !isPunctuation(Character))
                        {
                            getChar();
                            if (!isWhiteSpace(Character) && !isPunctuation(Character))
                            {
                                appendLine(Character);
                            }
                            else if (isWhiteSpace(Character))
                            {
                                appendLine(Character);
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    if (Line.Length > 256)
                    {
                        this.outputText(Line);
                        Line = "";
                        setProgessBar((int)(TotalByteCounter / progressBarStep));
                        setTotalValue(TotalByteCounter);
                        setOutputValue(OutputByteCounter);
                        setCompressedRatioValue((float)TotalByteCounter / (float)OutputByteCounter);
                    }
                }
                this.outputText(Line);
                setProgessBar((int)(TotalByteCounter / progressBarStep));
                setTotalValue(TotalByteCounter);
                setOutputValue(OutputByteCounter);
                setCompressedRatioValue((float)TotalByteCounter / (float)OutputByteCounter);
            }
        }
        private void workerThreadFunctionHTML()
        {
            Line = "";
            TotalByteCounter = 0;
            OutputByteCounter = 0;
            bool flagLineEmpty;
            EOFFlag = false;
            long fileSize = myStream.Length;
            long progressBarStep = fileSize / 100;
            setTotalValue(fileSize);
            using (myStream)
            {
                Byte = myStream.ReadByte();
                Byte = myStream.ReadByte();
                Byte = myStream.ReadByte();
                if (Byte != -1)
                {
                    Character = char.ConvertFromUtf32(Byte).ToCharArray()[0];
                    TotalByteCounter++;
                }
                while (Byte != -1)
                {
                    while (EOFFlag == false && Character != '>')
                    {
                        appendLine(getChar());
                    }
                    this.outputText(Line);
                    Line = "";
                    flagLineEmpty = true;
                    getChar();
                    while (EOFFlag == false && Character != '<')
                    {
                        if (flagLineEmpty)
                            if (!isWhiteSpace(Character))
                                flagLineEmpty = false;
                        appendLine(getChar());
                    }
                    if (!flagLineEmpty)
                    {
                        this.outputText(Line);
                    }
                    else
                    {
                        if (Character == '<')
                        {
                            this.outputText("<");
                        }
                    }
                    Line = "";
                    setProgessBar((int)(TotalByteCounter / progressBarStep));
                    setTotalValue(TotalByteCounter);
                    setOutputValue(OutputByteCounter);
                    setCompressedRatioValue((float)TotalByteCounter / (float)OutputByteCounter);
                }
                this.outputText(Line);
                setProgessBar((int)(TotalByteCounter / progressBarStep));
                setTotalValue(TotalByteCounter);
                setOutputValue(OutputByteCounter);
                setCompressedRatioValue((float)TotalByteCounter / (float)OutputByteCounter);
            }
        }
        private void workerThreadFunctionJS()
        {
            Line = "";
            TotalByteCounter = 0;
            OutputByteCounter = 0;
            EOFFlag = false;
            long fileSize = myStream.Length;
            long progressBarStep = fileSize / 100;
            setTotalValue(fileSize);
            using (myStream)
            {
                StreamWriter tempWriter = new StreamWriter("JS_Process.txt", false);
                while (Byte != -1)
                {
                    tempWriter.Write(getChar());
                }
                tempWriter.Close();
                setTotalValue(TotalByteCounter);
                //Passes Start here
                passDeleteMultiLineComments();
                setProgessBar(20);
                passDeleteComments();
                setProgessBar(40);
                passDeleteUselessSpace();
                setProgessBar(60);
                //Passes End here
                StreamReader tempReader = new StreamReader("JS_Process_Alt.txt");
                String line = tempReader.ReadLine();
                while (line != null)
                {
                    this.outputText(line);
                    line = tempReader.ReadLine();
                }
                tempReader.Close();
                //if (Character == ';' || isPunctuation(Character) || Character == '(' || Character == ')'
                //    || Character == '[' || Character == ']' || Character == '=' || Character == '(')
                //{
                //    while (!char.IsWhiteSpace(Character)) getChar();
                //}
                //if (Line.Length > 512)
                //{
                //    this.outputText(Line);
                //    Line = "";
                //}
            }
        }
        private void passDeleteMultiLineComments()
        {
            StreamWriter tempWriter = new StreamWriter("JS_Process_Alt.txt", false);
            StreamReader tempReader = new StreamReader("JS_Process.txt");
            int readByte;
            long BytesWritten = 0;
            bool flagComment = false;
            char chr, prevchr;
            readByte = tempReader.Read();
            prevchr = char.ConvertFromUtf32(readByte).ToCharArray()[0];
            readByte = tempReader.Read();
            while (readByte != -1)
            {
                chr = char.ConvertFromUtf32(readByte).ToCharArray()[0];
                if (prevchr == '/' && chr == '*')
                    flagComment = true;
                if (prevchr == '*' && chr == '/')
                    flagComment = false;
                if (!flagComment)
                {
                    tempWriter.Write(chr);
                    BytesWritten++;
                }
                prevchr = chr;
                readByte = tempReader.Read();
            }
            tempReader.Close();
            tempWriter.Close();
            setOutputValue(BytesWritten);
            setCompressedRatioValue((float)TotalByteCounter / (float)BytesWritten);
        }
        private void passDeleteComments()
        {
            StreamWriter tempWriter = new StreamWriter("JS_Process.txt", false);
            StreamReader tempReader = new StreamReader("JS_Process_Alt.txt");
            int readByte;
            long BytesWritten = 0;
            bool flagComment = false;
            char chr, prevchr;
            readByte = tempReader.Read();
            prevchr = char.ConvertFromUtf32(readByte).ToCharArray()[0];
            readByte = tempReader.Read();
            while (readByte != -1)
            {
                chr = char.ConvertFromUtf32(readByte).ToCharArray()[0];
                if (prevchr == '/' && chr == '/')
                    flagComment = true;
                if (chr == '\n')
                    flagComment = false;
                if (!flagComment)
                {
                    tempWriter.Write(chr);
                    BytesWritten++;
                }
                prevchr = chr;
                readByte = tempReader.Read();
            }
            tempReader.Close();
            tempWriter.Close();
            setOutputValue(BytesWritten);
            setCompressedRatioValue((float)TotalByteCounter / (float)BytesWritten);
        }
        private void passDeleteUselessSpace()
        {
            StreamWriter tempWriter = new StreamWriter("JS_Process_Alt.txt", false);
            StreamReader tempReader = new StreamReader("JS_Process.txt");
            int readByte;
            long BytesWritten = 0;
            bool flagRedundantWhiteSpace = false;
            char chr, prevchr;
            readByte = tempReader.Read();
            prevchr = char.ConvertFromUtf32(readByte).ToCharArray()[0];
            readByte = tempReader.Read();
            while (readByte != -1)
            {
                chr = char.ConvertFromUtf32(readByte).ToCharArray()[0];
                if (isWhiteSpace(prevchr) && isWhiteSpace(chr))
                    flagRedundantWhiteSpace = true;
                else
                    flagRedundantWhiteSpace = false;
                if (!flagRedundantWhiteSpace)
                {
                    tempWriter.Write(chr);
                    BytesWritten++;
                }
                prevchr = chr;
                readByte = tempReader.Read();
            }
            tempReader.Close();
            tempWriter.Close();
            setOutputValue(BytesWritten);
            setCompressedRatioValue((float)TotalByteCounter / (float)BytesWritten);
        }
        private char getChar()
        {
            Byte = myStream.ReadByte();
            TotalByteCounter++;
            if (Byte == -1)
            {
                EOFFlag = true;
                Character = ' ';
            }
            else
            {
                Character = char.ConvertFromUtf32(Byte).ToCharArray()[0];
            } return Character;
        }
        private bool isWhiteSpace(char test)
        {
            if (test == ' ' || test == '\n' || test == '\r' || test == '\t' || test == '\v')
                return true;
            else
                return false;
        }
        private bool isPunctuation(char test)
        {
            if (Character == ',' || Character == ':' || Character == ';' || Character == '{' || Character == '}')
                return true;
            else
                return false;
        }
        private void appendLine(Char chr)
        {
            Line += chr;
            OutputByteCounter++;
        }
    }
}
