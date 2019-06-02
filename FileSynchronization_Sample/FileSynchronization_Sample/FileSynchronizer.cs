using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSynchronization_Sample
{
    public class FileSynchronizer
    {
        /// <summary>
        /// Event Flags
        /// </summary>
        [Flags]
        public enum EVENTS
        {
            DELETED = 0x1,
            CHANGED = 0x2,
            CREATED = 0x4
        }

        /// <summary>
        /// Events
        /// </summary>
        private EVENTS _Events = EVENTS.CHANGED & EVENTS.CREATED & EVENTS.DELETED;

        /// <summary>
        /// Destination directory
        /// </summary>
        private readonly string Destination;

        /// <summary>
        /// Source directory
        /// </summary>
        private readonly string Source;

        /// <summary>
        /// The overly complicated FileSystemWatcher
        /// that we can simplify
        /// </summary>
        private readonly FileSystemWatcher FileSystemWatcher = new FileSystemWatcher();

        /// <summary>
        /// This is where we add the event hooks
        /// for the FileSynchronizer.
        /// </summary>
        public EVENTS Events
        {
            get { return _Events; }

            set
            {
                _Events = value;

                // unhook all events if needed
                this.FileSystemWatcher.Changed -= FileSystemWatcher_Changed;
                this.FileSystemWatcher.Created -= FileSystemWatcher_Created;
                this.FileSystemWatcher.Deleted -= FileSystemWatcher_Deleted;

                if ((_Events & EVENTS.CHANGED) == EVENTS.CHANGED)
                    this.FileSystemWatcher.Changed += FileSystemWatcher_Changed;

                if ((_Events & EVENTS.CREATED) == EVENTS.CREATED)
                    this.FileSystemWatcher.Created += FileSystemWatcher_Created;

                if ((_Events & EVENTS.DELETED) == EVENTS.DELETED)
                    this.FileSystemWatcher.Deleted += FileSystemWatcher_Deleted;
            }
        }

        /// <summary>
        /// FileSynchronizer Constructor
        /// </summary>
        /// <param name="Source">Source Directory Path</param>
        /// <param name="Destination">Destination Directory Path</param>
        /// <param name="Filter">File Filter</param>
        public FileSynchronizer(string Source, string Destination, string Filter = "*.*")
        {
            // check required parameters
            if (string.IsNullOrWhiteSpace(Source))
                throw new ArgumentNullException("Source");
            else if (string.IsNullOrWhiteSpace(Destination))
                throw new ArgumentNullException("Destination");

            // check source dir exists
            if (!Directory.Exists(Source))
                throw new Exception(string.Format("The source directory '{0}' does not exist.", Source));

            // create destination dir if needed
            if (!Directory.Exists(Destination))
                Directory.CreateDirectory(Destination);

            // set required fsw properties
            this.FileSystemWatcher.Path = Source;
            this.FileSystemWatcher.Filter = Filter;

            // store my paths for later
            this.Source = Source;
            this.Destination = Destination;
        }

        /// <summary>
        /// Fires when the a file is created so we can
        /// copy it to the destination.
        /// </summary>
        /// <param name="sender">FileSystemWatcher</param>
        /// <param name="e">FileSystemEventArgs</param>
        private void FileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {
            string path = e.FullPath.Replace(this.Source, this.Destination);

            if (File.Exists(path))
                return;

            if (!Directory.Exists(Path.GetDirectoryName(path)))
                Directory.CreateDirectory(Path.GetDirectoryName(path));

            File.Copy(e.FullPath, path);
        }

        /// <summary>
        /// Fires when a file is deleted so we can
        /// delete it from the destination.
        /// </summary>
        /// <param name="sender">FileSystemWatcher</param>
        /// <param name="e">FileSystemEventArgs</param>
        private void FileSystemWatcher_Deleted(object sender, FileSystemEventArgs e)
        {
            string path = e.FullPath.Replace(this.Source, this.Destination);

            if (File.Exists(path))
                File.Delete(path);
        }

        /// <summary>
        /// Fires when a file is changed so we can
        /// copy it to the destination.
        /// </summary>
        /// <param name="sender">FileSystemWatcher</param>
        /// <param name="e">FileSystemEventArgs</param>
        private void FileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            string path = e.FullPath.Replace(this.Source, this.Destination);

            if (File.Exists(path))
                if (File.GetLastWriteTimeUtc(path) == File.GetLastWriteTimeUtc(e.FullPath))
                    return;

            if (!Directory.Exists(Path.GetDirectoryName(path)))
                Directory.CreateDirectory(Path.GetDirectoryName(path));

            File.Copy(e.FullPath, path, true);
        }
    }
}
