﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Sitefinity.ContentLocations;
using Telerik.Sitefinity.Frontend.Media.Mvc.Helpers;
using Telerik.Sitefinity.Frontend.Mvc.Models;
using Telerik.Sitefinity.GenericContent.Model;
using Telerik.Sitefinity.Modules.Libraries;

namespace Telerik.Sitefinity.Frontend.Media.Mvc.Models.Video
{
    /// <summary>
    /// Provides API for working with <see cref="Telerik.Sitefinity.Libraries.Model.Video"/> items.
    /// </summary>
    public class VideoModel: IVideoModel
    {
        #region Properties

        /// <inheritdoc />
        public Guid Id { get; set; }

        /// <inheritdoc />
        public string ProviderName { get; set; }

        /// <inheritdoc />
        public string AspectRatio { get; set; }

        /// <inheritdoc />
        public int Width { get; set; }

        /// <inheritdoc />
        public int Height { get; set; }

        /// <inheritdoc />
        public int OriginallWidth { get; set; }

        /// <inheritdoc />
        public int OriginalHeight { get; set; }

        /// <inheritdoc />
        public string CssClass { get; set; }

        #endregion

        #region Public methods

        /// <inheritdoc />
        public virtual VideoViewModel GetViewModel()
        {
            var viewModel = new VideoViewModel();
            viewModel.CssClass = this.CssClass;

            if (this.Id != Guid.Empty)
            {
                LibrariesManager librariesManager = LibrariesManager.GetManager(this.ProviderName);
                var videoItem = librariesManager.GetVideos()
                    .Where(i => i.Id == this.Id)
                    .SingleOrDefault();

                if (videoItem == null || !videoItem.Visible || videoItem.Status != ContentLifecycleStatus.Live)
                    return viewModel;

                viewModel.HasSelectedVideo = true;
                viewModel.AspectRatio = this.AspectRatio;
                viewModel.Width = this.Width;
                viewModel.Height = this.Height;
                viewModel.Item = new ItemViewModel(videoItem);
            }

            return viewModel;
        }

        /// <inheritDoc/>
        public virtual IEnumerable<IContentLocationInfo> GetLocations()
        {
            return ContentLocationHelper.GetLocations(this.Id, this.ProviderName, typeof(Telerik.Sitefinity.Libraries.Model.Video));
        }

        #endregion
    }
}
