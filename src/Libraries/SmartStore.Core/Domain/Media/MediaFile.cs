using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using SmartStore.Core.Domain.Catalog;
using SmartStore.Core.Domain.Localization;

namespace SmartStore.Core.Domain.Media
{
	[DataContract]
	public partial class MediaFile : BaseEntity, ITransient, IHasMedia, IAuditable, ILocalizedEntity
	{
		private ICollection<ProductMediaFile> _productMediaFiles;
		private ICollection<MediaTag> _tags;

		#region Obsolete

		/// <summary>
		/// Gets or sets the picture binary
		/// </summary>
		[Obsolete("Use property MediaStorage instead")]
		public byte[] PictureBinary { get; set; }

		#endregion

		/// <summary>
		/// Gets or sets the SEO friendly name of the media file including file extension
		/// </summary>
		[DataMember]
		[Index("IX_Name")]
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the localizable image ALT text
		/// </summary>
		[DataMember]
		[Index("IX_Alt")]
		public string Alt { get; set; }

		/// <summary>
		/// Gets or sets the localizable media file title text
		/// </summary>
		[DataMember]
		public string Title { get; set; }

		/// <summary>
		/// Gets or sets the file extension
		/// </summary>
		[DataMember]
		[Index("IX_Extension")]
		public string Extension { get; set; }

		/// <summary>
		/// Gets or sets the file MIME type
		/// </summary>
		[DataMember]
		[Index("IX_MimeType")]
		public string MimeType { get; set; }

		/// <summary>
		/// Gets or sets the file media type (image, video, audio, document etc.)
		/// </summary>
		[DataMember]
		[Index("IX_MediaType")]
		public string MediaType { get; set; }

		/// <summary>
		/// Gets or sets the file size in bytes
		/// </summary>
		[DataMember]
		[Index("IX_Size")]
		public int Size { get; set; }

		/// <summary>
		/// Gets or sets the total pixel size of an image (width * height)
		/// </summary>
		[DataMember]
		[Index("IX_PixelSize")]
		public int? PixelSize { get; set; }

		/// <summary>
		/// Gets or sets the file metadata as raw JSON dictionary (width, height, video length, EXIF etc.)
		/// </summary>
		[DataMember]
		public string Metadata { get; set; }

		/// <summary>
		/// Gets or sets the image width (if file is an image)
		/// </summary>
		[DataMember]
		public int? Width { get; set; }

		/// <summary>
		/// Gets or sets the image height (if file is an image)
		/// </summary>
		[DataMember]
		public int? Height { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the file is new
        /// </summary>
		[DataMember]
		public bool IsNew { get; set; }

		/// <summary>
		/// Gets or sets the date and time of instance update
		/// </summary>
		[DataMember]
		[Index("IX_CreatedOn_IsTransient", 0)]
		public DateTime CreatedOnUtc { get; set; }

		/// <summary>
		/// Gets or sets the date and time of instance update
		/// </summary>
		[DataMember]
		//[Index("IX_UpdatedOn_IsTransient", 0)]
		public DateTime UpdatedOnUtc { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the file is transient/preliminary
		/// </summary>
		[DataMember]
		[Index("IX_CreatedOn_IsTransient", 1)]
		public bool IsTransient { get; set; }

		/// <summary>
		/// Gets or sets the media storage identifier
		/// </summary>
		[DataMember]
		public int? MediaStorageId { get; set; }

		/// <summary>
		/// Gets or sets the media storage
		/// </summary>
		public virtual MediaStorage MediaStorage { get; set; }

		/// <summary>
		/// Gets or sets the associated tags
		/// </summary>
		[DataMember]
		public virtual ICollection<MediaTag> Tags
		{
			get { return _tags ?? (_tags = new HashSet<MediaTag>()); }
			protected set { _tags = value; }
		}

		/// <summary>
		/// Gets or sets the product pictures
		/// </summary>
		[DataMember]
		public virtual ICollection<ProductMediaFile> ProductMediaFiles
        {
			get { return _productMediaFiles ?? (_productMediaFiles = new HashSet<ProductMediaFile>()); }
            protected set { _productMediaFiles = value; }
        }
    }
}
