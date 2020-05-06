using System;

namespace SeleniumFullTutorial.Model
{
    public class ProductStyleData
    {
        public ProductStyleData(){}
        public string Name { get; set; }
        public string RegularPrice { get; set; }
        public string RegularPriceColor { get; set; }
        public string RegularPriceTextStyle { get; set; }
        public string RegularPriceTextSize { get; set; }
        public string RegularPriceTextFront { get; set; }
        public string CampaignPrice { get; set; }
        public string CampaignPriceColor { get; set; }
        public string CampaignPriceTextStyle { get; set; }
        public string CampaignPriceTextSize { get; set; }
        public string CampaignPriceTextFront { get; set; }

        public bool Equals(ProductStyleData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            Console.WriteLine($"{Name} == {other.Name}");
            Console.WriteLine($"{RegularPrice} == {other.RegularPrice}");
            Console.WriteLine($"{CampaignPrice} == {other.CampaignPrice}");

            return Name == other.Name
                && RegularPrice == other.RegularPrice
                && CampaignPrice == other.CampaignPrice;
        }

        public bool IsValid()
        {
            return NormalizePrice(RegularPriceTextSize) < NormalizePrice(CampaignPriceTextSize)
                && GetColor(RegularPriceColor) == Color.Grey
                && GetColor(CampaignPriceColor) == Color.Red
                && RegularPriceTextStyle == "line-through" //Перечеркнутый текст 
                && CampaignPriceTextStyle == "none" // Нормальный текст. Значение по умолчанию
                && GetWeight(RegularPriceTextFront) == Weight.Normal
                && GetWeight(CampaignPriceTextFront) == Weight.Bold;
        }

        private double NormalizePrice(string price) => Double.Parse(price.Replace("px", "").Replace('.', ','));

        private Color GetColor(string code)
        {
            var s = code.Substring(code.IndexOf('(')).Replace("(", "").Replace(")", "").Replace(" ", "").Split(',');
            if(s[0] == s[1] && s[1]== s[2]) return Color.Grey;
            if(Int32.Parse(s[0]) > 0 && s[1] == "0" && s[2] == "0") return Color.Red;
            return Color.Unknown;
        }

        private Weight GetWeight(string weight)
        {
            //Когда задана произвольная толщина  400 - нормальный шрифт, 700 - толстый.
            if (Int32.Parse(weight) >= 700) return Weight.Bold;
            return Weight.Normal;
        }

        private enum Color
        {
            Red,
            Grey,
            Unknown
        }

        private enum Weight
        {
            Normal,
            Bold
        }
    }
}
