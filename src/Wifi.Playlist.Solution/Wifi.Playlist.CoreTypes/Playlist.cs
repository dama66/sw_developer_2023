using System;
using System.Collections.Generic;

namespace Wifi.Playlist.CoreTypes
{
    public class Playlist
    {
        private List<IPlaylistItem> _items;
		private string _name;
		private string _author;
		private DateTime _createdAt;

		public Playlist(string name, string author)
			: this(name, author, DateTime.Now) { }

        public Playlist(string name, string author, DateTime createAt)
        {
            _name = name;
            _author = author;

            _createdAt = createAt;
            _items = new List<IPlaylistItem>();
        }


        public DateTime CreatedAt
		{
			get { return _createdAt; }			
		}

		public string Author
		{
			get { return _author; }
			set { _author = value; }
		}

		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		public IEnumerable<IPlaylistItem> Items
		{
			get { return _items; }
		}

		public TimeSpan Duration
		{
			get
			{
				var sum = TimeSpan.Zero;

				if(_items.Count == 0)
				{
					return sum;
				}

				_items.ForEach(x => sum = sum.Add(x.Duration));

				return sum;
			}
		}


		public void Add(IPlaylistItem item)
		{
			if (item != null)
			{
				_items.Add(item);
			}
		}

		public void Remove(IPlaylistItem item)
		{
            if (item != null)
            {
                _items.Remove(item);
            }
        }

		public void Clear()
		{
			_items.Clear();
		}
	}
}
