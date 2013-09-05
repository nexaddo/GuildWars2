﻿using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

#if SILVERLIGHT
using System.IO;
using System.Windows.Markup;
#endif

namespace GuildWars2.ArenaNet.Mapper
{
    public abstract class ImagePushpin : TemplatedPushpin
    {
        private static string IMAGEBRUSH_NAME = "ImagePushpinTemplateBrush";

        protected static BitmapImage LoadImageResource(string resourceUri)
        {
#if SILVERLIGHT
            return new BitmapImage(new Uri(string.Format("/GuildWars2.ArenaNet.Mapper.Silverlight;component{0}", resourceUri), UriKind.Relative));
#else
            return new BitmapImage(new Uri(string.Format("pack://application:,,,/GuildWars2.ArenaNet.Mapper;component{0}", resourceUri)));
#endif
        }

        private bool m_TemplateApplied = false;

        private BitmapImage m_Image;
        public BitmapImage Image
        {
            get { return m_Image; }
            set
            {
                m_Image = value;

                if (m_TemplateApplied)
                {
                    ImageBrush brush = (ImageBrush)GetTemplateChild(IMAGEBRUSH_NAME);
                    brush.ImageSource = m_Image;
                }
            }
        }

#if SILVERLIGHT
        public string ToolTip
        {
            get { return ToolTipService.GetToolTip(this).ToString(); }
            set { ToolTipService.SetToolTip(this, value); }
        }
#endif

        public ImagePushpin()
            : base("/ImagePushpinTemplate.xaml")
        {
            Width = 20;
            Height = 20;
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            m_TemplateApplied = true;
        }
    }
}