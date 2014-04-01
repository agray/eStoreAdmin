#region Licence
/*
 * The MIT License
 *
 * Copyright (c) 2008-2013, Andrew Gray
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */
#endregion
using System.Collections.Generic;
using System.IO;
using Ionic.Zip;

namespace PhoenixConsulting.Zipper.DotNetZip {
    public class DotNetZipper {

        private ZipFile zipFile;
        private string sep = @"\";

        public DotNetZipper(string tempFolder) {
            zipFile = new ZipFile();
            zipFile.TempFileFolder = tempFolder;
        }

        public void addFiles(List<string> files) {
            foreach(var f in files) {
                zipFile.AddFile(f);
            }
        }

        public void addFile(string file) {
            zipFile.AddFile(file);
        }

        public void addFiles(List<string> files, string directoryPathInArchive) {
            foreach(var f in files) {
                zipFile.AddFile(f, directoryPathInArchive);
            }
        }

        public void addEntry(string entryName, byte[] content) {
            zipFile.AddEntry(entryName, content);
        }

        public void addEntry(string entryName, string content) {
            zipFile.AddEntry(entryName, content);
        }

        public void save() {
            zipFile.Save();
        }

        public void save(string fileName) {
            zipFile.Save(zipFile.TempFileFolder + sep + fileName);
        }

        public void save(Stream outputStream) {
            zipFile.Save(outputStream);
        }
    }
}