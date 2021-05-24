using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Data;

namespace LasHelper
{

    /// <summary>
    /// Class to write data to a las file
    /// </summary>
    public sealed class LasWriter:IDisposable
    {

        #region Members

        private StreamWriter _streamWriter;
        private bool _replaceCarriageReturnsAndLineFeedsFromFieldValues = true;
        private string _carriageReturnAndLineFeedReplacement = ",";

        #endregion Members

        #region Properties

        /// <summary>
        /// Gets or sets whether carriage returns and line feeds should be removed from 
        /// field values, the default is true 
        /// </summary>
        public bool ReplaceCarriageReturnsAndLineFeedsFromFieldValues
        {
            get
            {
                return _replaceCarriageReturnsAndLineFeedsFromFieldValues;
            }
            set
            {
                _replaceCarriageReturnsAndLineFeedsFromFieldValues = value;
            }
        }

        /// <summary>
        /// Gets or sets what the carriage return and line feed replacement characters should be
        /// </summary>
        public string CarriageReturnAndLineFeedReplacement
        {
            get
            {
                return _carriageReturnAndLineFeedReplacement;
            }
            set
            {
                _carriageReturnAndLineFeedReplacement = value;
            }
        }

        #endregion Properties

        #region Methods

        #region LasFile write methods

        /// <summary>
        /// Writes Las content to a file
        /// </summary>
        /// <param name="LasFile">LasFile</param>
        /// <param name="filePath">File path</param>
        public void WriteLas(LasFile LasFile, string filePath)
        {
            WriteLas(LasFile, filePath, null);
        }

        /// <summary>
        /// Writes Las content to a file
        /// </summary>
        /// <param name="LasFile">LasFile</param>
        /// <param name="filePath">File path</param>
        /// <param name="encoding">Encoding</param>
        public void WriteLas(LasFile LasFile, string filePath, Encoding encoding)
        {
            if (File.Exists(filePath))
                File.Delete(filePath);

            using (StreamWriter writer = new StreamWriter(filePath, false, encoding ?? Encoding.Default))
            {
                WriteToStream(LasFile, writer);
                writer.Flush();
                writer.Close();
            }
        }

        /// <summary>
        /// Writes Las content to a stream
        /// </summary>
        /// <param name="LasFile">LasFile</param>
        /// <param name="stream">Stream</param>
        public void WriteLas(LasFile LasFile, Stream stream)
        {
            WriteLas(LasFile, stream, null);
        }

        /// <summary>
        /// Writes Las content to a stream
        /// </summary>
        /// <param name="LasFile">LasFile</param>
        /// <param name="stream">Stream</param>
        /// <param name="encoding">Encoding</param>
        public void WriteLas(LasFile LasFile, Stream stream, Encoding encoding)
        {
            stream.Position = 0;
            _streamWriter = new StreamWriter(stream, encoding ?? Encoding.Default);
            WriteToStream(LasFile, _streamWriter);
            _streamWriter.Flush();
            stream.Position = 0;
        }

        /// <summary>
        /// Writes Las content to a string
        /// </summary>
        /// <param name="LasFile">LasFile</param>
        /// <param name="encoding">Encoding</param>
        /// <returns>Las content in a string</returns>
        public string WriteLas(LasFile LasFile, Encoding encoding)
        {
            string content = string.Empty;

            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (StreamWriter writer = new StreamWriter(memoryStream, encoding ?? Encoding.Default))
                {
                    WriteToStream(LasFile, writer);
                    writer.Flush();
                    memoryStream.Position = 0;

                    using (StreamReader reader = new StreamReader(memoryStream, encoding ?? Encoding.Default))
                    {
                        content = reader.ReadToEnd();
                        writer.Close();
                        reader.Close();
                        memoryStream.Close();
                    }
                }
            }

            return content;
        }

        #endregion LasFile write methods

        #region DataTable write methods

        /// <summary>
        /// Writes a DataTable to a file
        /// </summary>
        /// <param name="dataTable">DataTable</param>
        /// <param name="filePath">File path</param>
        public void WriteLas(DataTable dataTable, string filePath)
        {
            WriteLas(dataTable, filePath, null);
        }

        /// <summary>
        /// Writes a DataTable to a file
        /// </summary>
        /// <param name="dataTable">DataTable</param>
        /// <param name="filePath">File path</param>
        /// <param name="encoding">Encoding</param>
        public void WriteLas(DataTable dataTable, string filePath, Encoding encoding)
        {
            if (File.Exists(filePath))
                File.Delete(filePath);

            using (StreamWriter writer = new StreamWriter(filePath, false, encoding ?? Encoding.Default))
            {
                WriteToStream(dataTable, writer);
                writer.Flush();
                writer.Close();
            }
        }

        /// <summary>
        /// Writes a DataTable to a stream
        /// </summary>
        /// <param name="dataTable">DataTable</param>
        /// <param name="stream">Stream</param>
        public void WriteLas(DataTable dataTable, Stream stream)
        {
            WriteLas(dataTable, stream, null);
        }

        /// <summary>
        /// Writes a DataTable to a stream
        /// </summary>
        /// <param name="dataTable">DataTable</param>
        /// <param name="stream">Stream</param>
        /// <param name="encoding">Encoding</param>
        public void WriteLas(DataTable dataTable, Stream stream, Encoding encoding)
        {
            stream.Position = 0;
            _streamWriter = new StreamWriter(stream, encoding ?? Encoding.Default);
            WriteToStream(dataTable, _streamWriter);
            _streamWriter.Flush();
            stream.Position = 0;
        }

        /// <summary>
        /// Writes the DataTable to a string
        /// </summary>
        /// <param name="dataTable">DataTable</param>
        /// <param name="encoding">Encoding</param>
        /// <returns>Las content in a string</returns>
        public string WriteLas(DataTable dataTable, Encoding encoding)
        {
            string content = string.Empty;

            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (StreamWriter writer = new StreamWriter(memoryStream, encoding ?? Encoding.Default))
                {
                    WriteToStream(dataTable, writer);
                    writer.Flush();
                    memoryStream.Position = 0;

                    using (StreamReader reader = new StreamReader(memoryStream, encoding ?? Encoding.Default))
                    {
                        content = reader.ReadToEnd();
                        writer.Close();
                        reader.Close();
                        memoryStream.Close();
                    }
                }
            }

            return content;
        }

        #endregion DataTable write methods

        /// <summary>
        /// Writes the Las File
        /// </summary>
        /// <param name="LasFile">LasFile</param>
        /// <param name="writer">TextWriter</param>
        private void WriteToStream(LasFile LasFile, TextWriter writer)
        {
            if (LasFile.Headers.Count > 0)
                WriteRecord(LasFile.Headers, writer);

            LasFile.Records.ForEach(record => WriteRecord(record.Fields, writer));
        }

        /// <summary>
        /// Writes the Las File
        /// </summary>
        /// <param name="dataTable">DataTable</param>
        /// <param name="writer">TextWriter</param>
        private void WriteToStream(DataTable dataTable, TextWriter writer)
        {
            List<string> fields = (from DataColumn column in dataTable.Columns select column.ColumnName).ToList();
            WriteRecord(fields, writer);

            foreach (DataRow row in dataTable.Rows)
            {
                fields.Clear();
                fields.AddRange(row.ItemArray.Select(o => o.ToString()));
                WriteRecord(fields, writer);
            }
        }

        /// <summary>
        /// Writes the record to the underlying stream
        /// </summary>
        /// <param name="fields">Fields</param>
        /// <param name="writer">TextWriter</param>
        private void WriteRecord(IList<string> fields, TextWriter writer)
        {
            for (int i = 0; i < fields.Count; i++)
            {
                bool quotesRequired = fields[i].Contains(",");
                bool escapeQuotes = fields[i].Contains("\"");
                string fieldValue = (escapeQuotes ? fields[i].Replace("\"", "\"\"") : fields[i]);

                if (ReplaceCarriageReturnsAndLineFeedsFromFieldValues && (fieldValue.Contains("\r") || fieldValue.Contains("\n")))
                {
                    quotesRequired = true;
                    fieldValue = fieldValue.Replace("\r\n", CarriageReturnAndLineFeedReplacement);
                    fieldValue = fieldValue.Replace("\r", CarriageReturnAndLineFeedReplacement);
                    fieldValue = fieldValue.Replace("\n", CarriageReturnAndLineFeedReplacement);
                }

                writer.Write(string.Format("{0}{1}{0}{2}",
                    (quotesRequired || escapeQuotes ? "\"" : string.Empty),
                    fieldValue,
                    (i < (fields.Count - 1) ? "," : string.Empty)));
            }

            writer.WriteLine();
        }

        /// <summary>
        /// Disposes of all unmanaged resources
        /// </summary>
        public void Dispose()
        {
            if (_streamWriter == null)
                return;

            _streamWriter.Close();
            _streamWriter.Dispose();
        }

        #endregion Methods
    }
}
