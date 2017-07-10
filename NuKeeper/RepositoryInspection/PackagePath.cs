﻿using System;
using System.IO;

namespace NuKeeper.RepositoryInspection
{
    public class PackagePath
    {
        public PackagePath(string baseDirectory, string relativePath, 
            PackageReferenceType packageReferenceType)
        {
            if (string.IsNullOrWhiteSpace(baseDirectory))
            {
                throw new ArgumentException(nameof(baseDirectory));
            }

            if (string.IsNullOrWhiteSpace(relativePath))
            {
                throw new ArgumentException(nameof(relativePath));
            }

            if (relativePath[0] == Path.DirectorySeparatorChar)
            {
                relativePath = relativePath.Substring(1);
            }

            BaseDirectory = baseDirectory;
            RelativePath = relativePath;
            PackageReferenceType = packageReferenceType;

            FileName = Path.GetFileName(relativePath);

            FullPath = Path.Combine(baseDirectory, relativePath);
            FullDirectory = Path.GetDirectoryName(FullPath);
        }

        /// <summary>
        /// The working directory at the root of all the files
        /// </summary>
        public string BaseDirectory { get; }

        /// <summary>
        /// The full directory path to the file, without file name
        /// </summary>
        public string FullDirectory { get; }

        /// <summary>
        /// Path from BaseDirectory to the file, includes file name
        /// </summary>
        public string RelativePath { get; }

        /// <summary>
        /// Just the file name
        /// </summary>
        public string FileName { get; }

        /// <summary>
        /// Full path to the file
        /// </summary>
        public string FullPath { get; }

        public PackageReferenceType PackageReferenceType { get; }
    }
}