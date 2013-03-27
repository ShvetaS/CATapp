using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.IsolatedStorage;
using System.Windows.Resources;
using System.IO;

namespace CATapp
{
    class DBMover
    {
        public static void MoveIntialDB()
        {
            IsolatedStorageFile isostore = IsolatedStorageFile.GetUserStoreForApplication();

            if (!isostore.FileExists("catappdb.sdf"))
            {
                StreamResourceInfo sri = App.GetResourceStream(new Uri("catappdb.sdf", UriKind.Relative));

                IsolatedStorageFileStream isfs = new IsolatedStorageFileStream("catappdb.sdf", FileMode.Create, IsolatedStorageFile.GetUserStoreForApplication());

                long FileLength = (long)sri.Stream.Length;
                byte[] byteInput = new byte[FileLength];
                sri.Stream.Read(byteInput, 0, byteInput.Length);
                isfs.Write(byteInput, 0, byteInput.Length);

                sri.Stream.Close();
                isfs.Close();
            }

        }
    }
}
