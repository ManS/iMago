using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Utilities
{
    public struct ImageLogEntry : IDisposable
    {
        public string OperationName;
        public Bitmap Image;
        
        public ImageLogEntry(Bitmap p_image, string p_operationName)
        {
            OperationName = p_operationName;
            Image = p_image;
        }

        public void Dispose()
        {
            Image.Dispose();
        }
    }
    
    public class ImageProcessingLog : IImageProcessingLog
    {
        public Dictionary<int, ImageLogEntry> ProcessingLog { get; private set; }

        public ImageProcessingLog()
        {
            this.ProcessingLog = new Dictionary<int, ImageLogEntry>();
        }

        public void AddImage(int key, Bitmap p_image, string p_operationName)
        {
            Bitmap imageToStore = (Bitmap)p_image.Clone();

            if (ProcessingLog.ContainsKey(key))
            {
                ProcessingLog[key].Dispose();
                ProcessingLog[key] = new ImageLogEntry(imageToStore,p_operationName);
            }
            else
            {
                ProcessingLog.Add(key, new ImageLogEntry(imageToStore, p_operationName));
            }
        }

        public void Clear()
        {
            if (this.ProcessingLog == null)
                return;
            ImageLogEntry firstEntry = new ImageLogEntry();
            foreach (KeyValuePair<int, ImageLogEntry> logEntry in this.ProcessingLog)
            {
                if (logEntry.Key == 0)
                {
                    firstEntry = logEntry.Value;
                    continue;
                }
                logEntry.Value.Dispose();
            }
            ProcessingLog.Clear();
            ProcessingLog.Add(0, firstEntry);
        }
    }
}