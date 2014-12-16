using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class News
    {
        private int newsId;

        public int NewsId
        {
            get { return newsId; }
            set { newsId = value; }
        }
        private string newsTitle;

        public string NewsTitle
        {
            get { return newsTitle; }
            set { newsTitle = value; }
        }
        private int newsType;

        public int NewsType
        {
            get { return newsType; }
            set { newsType = value; }
        }
        private string newsContent;

        public string NewsContent
        {
            get { return newsContent; }
            set { newsContent = value; }
        }
        private string newsAuthor;

        public string NewsAuthor
        {
            get { return newsAuthor; }
            set { newsAuthor = value; }
        }
        private DateTime newsCreateTime;

        public DateTime NewsCreateTime
        {
            get { return newsCreateTime; }
            set { newsCreateTime = value; }
        }
        private DateTime newsLastModified;

        public DateTime NewsLastModified
        {
            get { return newsLastModified; }
            set { newsLastModified = value; }
        }
        private int newsSequence;

        public int NewsSequence
        {
            get { return newsSequence; }
            set { newsSequence = value; }
        }
        private string newsImg;

        public string NewsImg
        {
            get { return newsImg; }
            set { newsImg = value; }
        }
        private int newsBrowseCount;

        public int NewsBrowseCount
        {
            get { return newsBrowseCount; }
            set { newsBrowseCount = value; }
        }
        private string newsSource;

        public string NewsSource
        {
            get { return newsSource; }
            set { newsSource = value; }
        }
        private DateTime newsPublishTime;

        public DateTime NewsPublishTime
        {
            get { return newsPublishTime; }
            set { newsPublishTime = value; }
        }
        private bool newsIsDisplay;

        public bool NewsIsDisplay
        {
            get { return newsIsDisplay; }
            set { newsIsDisplay = value; }
        }
    }
}
