using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace iMago
{
    public class ImageManipulator : IManipulatorSubject
    {

        #region Properties
        public MyImage Image { get; private set; }
        public ImagePanel ImagePanel { get; set; }
        public int TabIndex { get; private set; }
        public List<IManipulatorObserver> Observers { get; private set; }
        #endregion

        #region Constructor
        public ImageManipulator(MyImage p_image, ImagePanel p_imagePanel, int p_tabIndex)
        {
            this.TabIndex = p_tabIndex;
            this.Image = p_image;
            this.ImagePanel = p_imagePanel;
            this.Observers = new List<IManipulatorObserver>();
        }
        #endregion

        #region IManipulatorSubject Members
       
        public void NotifyUpdated(string p_operation)
        {
            this.Image.Update(this.ImagePanel.Image);
            this.Image.AddImageToHistory(p_operation);
            
            foreach (IManipulatorObserver Observer in this.Observers)
            {
                Observer.OnUpdateHistory(this.TabIndex,this.Image.ProcessingHistory);
            }
        }
        
        public void RegisterObserver(IManipulatorObserver p_observer)
        {
            this.Observers.Add(p_observer);
        }

        public void UnRegisterObserver(IManipulatorObserver p_observer)
        {
            this.Observers.Remove(p_observer);
        }
        
        #endregion

        public void NotifyUpdateHistogram(Bitmap p_newImage)
        {
            foreach (IManipulatorObserver Observer in this.Observers)
            {
                Observer.OnUpdateHistogram(p_newImage);
            }
        }

        public void SetHistoryPointer(int p_historyPointer)
        {
            this.Image.BitmapImage = this.Image.RetrieveImageFromHistory(p_historyPointer);
            this.Image.UpdateImageStatistics();
            this.ImagePanel.Image = this.Image.BitmapImage;
        }

        internal void Reset()
        {
            this.ImagePanel.Image = this.Image.BitmapImage;
        }

        public void ClearHistory()
        {
            this.ImagePanel.Image = this.Image.RetrieveImageFromHistory(0);
            this.Image.BitmapImage = new Bitmap(this.ImagePanel.Image);
            this.Image.ClearHistory();
            foreach (IManipulatorObserver Observer in this.Observers)
            {
                Observer.OnClearHistory();
            }
        }
    }
}
