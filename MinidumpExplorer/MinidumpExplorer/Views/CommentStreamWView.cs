using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DbgHelp.MinidumpFiles;

namespace MinidumpExplorer.Views
{
    public partial class CommentStreamWView : BaseViewControl
    {
        private MiniDumpCommentStreamW _commentWStream;

        public CommentStreamWView()
        {
            InitializeComponent();
        }

        public CommentStreamWView(MiniDumpCommentStreamW commentWStream)
            : this()
        {
            _commentWStream = commentWStream;

            if (commentWStream.Comment == null)
                AddInfoNode("No data found for stream");
            else
                AddInfoNode(commentWStream.Comment);
        }

        private void AddInfoNode(string value)
        {
            textBox1.Text = value;
        }
    }
}
