﻿using Storage.Serializable;

namespace Logic.Models
{
    public class DraftModel
    {
        public DraftModel(Draft draft)
        {
            Order = draft?.Id ?? 0;
            Text = draft?.Desc ?? string.Empty;
        }

        public int Order { get; set; }
        public string Text { get; set; }
    }
}