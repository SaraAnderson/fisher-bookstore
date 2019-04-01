using System;

namespace Fisher.Bookstore.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string ISBN { get; set; }
        
        public DateTime publicationDate { get; set; }
        public string Publisher { get; set; }
        public DateTime PublishDate { get; set; }

        public void ChangePublicationDate(DateTime dateTime)
        {
            this.PublishDate = dateTime;
        }

        public void ChangePublisher(string newPublisher)
        {
            this.Publisher = newPublisher;
        }

        public void ChangeTitle(string newTitle)
        {
            this.Title = newTitle;
        }
    }
}