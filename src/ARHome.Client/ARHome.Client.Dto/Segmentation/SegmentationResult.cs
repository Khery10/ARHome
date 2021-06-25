namespace ARHome.Client.Segmentation
{
    public sealed class SegmentationResult
    {
        /// <summary>
        /// Wall mask.
        /// </summary>
        public string Wall { get; set; }
        
        /// <summary>
        /// Floor mask.
        /// </summary>
        public string Floor { get; set; }
        
        /// <summary>
        /// Result image.
        /// </summary>
        public string Image { get; set; }
    }
}