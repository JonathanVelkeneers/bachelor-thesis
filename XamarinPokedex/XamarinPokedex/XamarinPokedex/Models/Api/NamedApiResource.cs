namespace XamarinPokedex.Models
{
    public abstract class NamedApiResource : ApiResource
    {
        private string _name;
        public string Name
        {
            get
            {
                return char.ToUpper(_name[0]) + _name.Substring(1);
            }
            set
            {
                _name = value;
            }
        }
    }
}
