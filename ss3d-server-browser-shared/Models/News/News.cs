namespace ss3d_server_browser_shared.Models.News
{
    public class News
    {
        /// <summary>id of this news item in the database</summary>
        public virtual int Id { get; set; }

        /// <summary>Server this news belongs to. -1 means no server</summary>
        public virtual int BelongingServer { get; set; }

        // Header image field
        /// <summary>Title of this news item</summary>
        public virtual string Title { get; set; }
        /// <summary>Subtitle of this news item</summary>
        public virtual string SubTitle { get; set; }
        /// <summary>Date of posting</summary>
        public virtual long Date { get; set; }
        /// <summary>Category for this news item (server, game, balance, etc). Empty means none</summary>
        public virtual string Category { get; set; }

        /// <summary>Markdown formatted content for this news item</summary>
        public virtual string MarkdownContent { get; set; }
    }
}