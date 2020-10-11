using Humanizer;
using System;

namespace XamarinFormsTemplate.Models
{
    public class Item
    {
        public DateTime AddedOn { get; set; }
        public string AddedOnText => AddedOn.Humanize();
        public string Description { get; set; }
        public string Id { get; set; }
        public string Text { get; set; }
    }
}