using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TMP.Graphics
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    [Serializable]
    public class Colour
    {
        public byte Red = 0;
        public byte Green = 0;
        public byte Blue = 0;
        public byte Alpha = 255;

        public Colour() 
        { }

        public Colour(byte r, byte g, byte b, byte a = 255)
        {
            this.Red = r;
            this.Green = g;
            this.Blue = b;
            this.Alpha = a;
        }

        public Colour(float r, float g, float b, float a = 1f)
        {
            this.Red = (byte)(r * 255);
            this.Green = (byte)(g * 255);
            this.Blue = (byte)(b * 255);
            this.Alpha = (byte)(a * 255);
        }

        public override string ToString()
        {
            return $"RGBA({Red},{Green},{Blue},{Alpha})";
        }

        public static Colour HSL(byte h, byte s, byte l) => Colour.HSL(h / 255f, s / 255f, l / 255f);

        public static Colour HSL(float h, float s, float l)
        {
            float r = 0, g = 0, b = 0;
            if (l != 0)
            {
                if (s == 0)
                    r = g = b = l;
                else
                {
                    float temp2;
                    if (l < 0.5)
                        temp2 = l * (1.0f + s);
                    else
                        temp2 = l + s - (l * s);

                    float temp1 = 2.0f * l - temp2;

                    r = GetColorComponent(temp1, temp2, h + 1.0f / 3.0f);
                    g = GetColorComponent(temp1, temp2, h);
                    b = GetColorComponent(temp1, temp2, h - 1.0f / 3.0f);
                }
            }
            return new Colour(r, g, b);


            static float GetColorComponent(float temp1, float temp2, float temp3)
            {
                if (temp3 < 0.0f)
                    temp3 += 1.0f;
                else if (temp3 > 1.0f)
                    temp3 -= 1.0f;

                if (temp3 < 1.0f / 6.0f)
                    return temp1 + (temp2 - temp1) * 6.0f * temp3;
                else if (temp3 < 0.5f)
                    return temp2;
                else if (temp3 < 2.0f / 3.0f)
                    return temp1 + ((temp2 - temp1) * ((2.0f / 3.0f) - temp3) * 6.0f);
                else
                    return temp1;
            }
        }

        

        public static Colour operator /(Colour a, Colour b)
        {
            Colour result = new Colour();
            result.Red = (byte)((a.Red + b.Red) / 2);
            result.Green = (byte)((a.Green + b.Green) / 2);
            result.Blue = (byte)((a.Blue + b.Blue) / 2);
            result.Alpha = (byte)((a.Alpha + b.Alpha) / 2);

            return result;
        }

        public static Colour operator +(Colour a, Colour b)
        {
            Colour result = new Colour();

            result.Red = (byte)(MathF.Min(a.Red + b.Red, byte.MaxValue));
            result.Green = (byte)(MathF.Min(a.Green + b.Green, byte.MaxValue));
            result.Blue = (byte)(MathF.Min(a.Blue + b.Blue, byte.MaxValue));
            result.Alpha = (byte)(MathF.Min(a.Alpha + b.Alpha, byte.MaxValue));

            return result;
        }

        #region ReadOnly Colors

        public static readonly Colour AliceBlue = new Colour(0.9411765f, 0.972549f, 1f);
        public static readonly Colour AntiqueWhite = new Colour(0.9803922f, 0.9215686f, 0.8431373f);
        public static readonly Colour Aquamarine = new Colour(0.4980392f, 1f, 0.8313726f);
        public static readonly Colour Azure = new Colour(0.9411765f, 1f, 1f);
        public static readonly Colour Beige = new Colour(0.9607843f, 0.9607843f, 0.8627451f);
        public static readonly Colour Bisque = new Colour(1f, 0.8941177f, 0.7686275f);
        public static readonly Colour Black = new Colour(0f, 0f, 0f);
        public static readonly Colour BlanchedAlmond = new Colour(1f, 0.9215686f, 0.8039216f);
        public static readonly Colour PureBlue = new Colour(0f, 0f, 1f);
        public static readonly Colour BlueViolet = new Colour(0.5411765f, 0.1686275f, 0.8862745f);
        public static readonly Colour Brown = new Colour(0.6470588f, 0.1647059f, 0.1647059f);
        public static readonly Colour BurlyWood = new Colour(0.8705882f, 0.7215686f, 0.5294118f);
        public static readonly Colour CadetBlue = new Colour(0.372549f, 0.6196079f, 0.627451f);
        public static readonly Colour Chartreuse = new Colour(0.4980392f, 1f, 0f);
        public static readonly Colour Chocolate = new Colour(0.8235294f, 0.4117647f, 0.1176471f);
        public static readonly Colour Coral = new Colour(1f, 0.4980392f, 0.3137255f);
        public static readonly Colour CornflowerBlue = new Colour(0.3921569f, 0.5843138f, 0.9294118f);
        public static readonly Colour Cornsilk = new Colour(1f, 0.972549f, 0.8627451f);
        public static readonly Colour Crimson = new Colour(0.8627451f, 0.07843138f, 0.2352941f);
        public static readonly Colour DarkBlue = new Colour(0f, 0f, 0.5450981f);
        public static readonly Colour DarkCyan = new Colour(0f, 0.5450981f, 0.5450981f);
        public static readonly Colour DarkGoldenrod = new Colour(0.7215686f, 0.5254902f, 0.04313726f);
        public static readonly Colour DarkGreen = new Colour(0f, 0.3921569f, 0f);
        public static readonly Colour DarkKhaki = new Colour(0.7411765f, 0.7176471f, 0.4196078f);
        public static readonly Colour DarkMagenta = new Colour(0.5450981f, 0f, 0.5450981f);
        public static readonly Colour DarkOliveGreen = new Colour(0.3333333f, 0.4196078f, 0.1843137f);
        public static readonly Colour DarkOrange = new Colour(1f, 0.5490196f, 0f);
        public static readonly Colour DarkOrchid = new Colour(0.6f, 0.1960784f, 0.8f);
        public static readonly Colour DarkRed = new Colour(0.5450981f, 0f, 0f);
        public static readonly Colour DarkSalmon = new Colour(0.9137255f, 0.5882353f, 0.4784314f);
        public static readonly Colour DarkSeaGreen = new Colour(0.5607843f, 0.7372549f, 0.5607843f);
        public static readonly Colour DarkSlateBlue = new Colour(0.282353f, 0.2392157f, 0.5450981f);
        public static readonly Colour DarkTurquoise = new Colour(0f, 0.8078431f, 0.8196079f);
        public static readonly Colour DarkViolet = new Colour(0.5803922f, 0f, 0.827451f);
        public static readonly Colour DeepPink = new Colour(1f, 0.07843138f, 0.5764706f);
        public static readonly Colour DeepSkyBlue = new Colour(0f, 0.7490196f, 1f);
        public static readonly Colour DodgerBlue = new Colour(0.1176471f, 0.5647059f, 1f);
        public static readonly Colour FireBrick = new Colour(0.6980392f, 0.1333333f, 0.1333333f);
        public static readonly Colour FloralWhite = new Colour(1f, 0.9803922f, 0.9411765f);
        public static readonly Colour ForestGreen = new Colour(0.1333333f, 0.5450981f, 0.1333333f);
        public static readonly Colour Gainsboro = new Colour(0.8627451f, 0.8627451f, 0.8627451f);
        public static readonly Colour GhostWhite = new Colour(0.972549f, 0.972549f, 1f);
        public static readonly Colour Gold = new Colour(1f, 0.8431373f, 0f);
        public static readonly Colour Goldenrod = new Colour(0.854902f, 0.6470588f, 0.1254902f);
        public static readonly Colour PureGreen = new Colour(0f, 1f, 0f);
        public static readonly Colour GreenYellow = new Colour(0.6784314f, 1f, 0.1843137f);
        public static readonly Colour Honeydew = new Colour(0.9411765f, 1f, 0.9411765f);
        public static readonly Colour HotPink = new Colour(1f, 0.4117647f, 0.7058824f);
        public static readonly Colour IndianRed = new Colour(0.8039216f, 0.3607843f, 0.3607843f);
        public static readonly Colour Indigo = new Colour(0.2941177f, 0f, 0.509804f);
        public static readonly Colour Ivory = new Colour(1f, 1f, 0.9411765f);
        public static readonly Colour Khaki = new Colour(0.9411765f, 0.9019608f, 0.5490196f);
        public static readonly Colour Lavender = new Colour(0.9019608f, 0.9019608f, 0.9803922f);
        public static readonly Colour LavenderBlush = new Colour(1f, 0.9411765f, 0.9607843f);
        public static readonly Colour LawnGreen = new Colour(0.4862745f, 0.9882353f, 0f);
        public static readonly Colour LemonChiffon = new Colour(1f, 0.9803922f, 0.8039216f);
        public static readonly Colour LightBlue = new Colour(0.6784314f, 0.8470588f, 0.9019608f);
        public static readonly Colour LightCoral = new Colour(0.9411765f, 0.5019608f, 0.5019608f);
        public static readonly Colour LightCyan = new Colour(0.8784314f, 1f, 1f);
        public static readonly Colour LightGoldenrodYellow = new Colour(0.9803922f, 0.9803922f, 0.8235294f);
        public static readonly Colour LightGreen = new Colour(0.5647059f, 0.9333333f, 0.5647059f);
        public static readonly Colour LightPink = new Colour(1f, 0.7137255f, 0.7568628f);
        public static readonly Colour LightSalmon = new Colour(1f, 0.627451f, 0.4784314f);
        public static readonly Colour LightSeaGreen = new Colour(0.1254902f, 0.6980392f, 0.6666667f);
        public static readonly Colour LightSkyBlue = new Colour(0.5294118f, 0.8078431f, 0.9803922f);
        public static readonly Colour LightSteelBlue = new Colour(0.6901961f, 0.7686275f, 0.8705882f);
        public static readonly Colour LightYellow = new Colour(1f, 1f, 0.8784314f);
        public static readonly Colour Lime = new Colour(0f, 1f, 0f);
        public static readonly Colour LimeGreen = new Colour(0.1960784f, 0.8039216f, 0.1960784f);
        public static readonly Colour Linen = new Colour(0.9803922f, 0.9411765f, 0.9019608f);
        public static readonly Colour Maroon = new Colour(0.5019608f, 0f, 0f);
        public static readonly Colour MediumAquamarine = new Colour(0.4f, 0.8039216f, 0.6666667f);
        public static readonly Colour MediumBlue = new Colour(0f, 0f, 0.8039216f);
        public static readonly Colour MediumOrchid = new Colour(0.7294118f, 0.3333333f, 0.827451f);
        public static readonly Colour MediumPurple = new Colour(0.5764706f, 0.4392157f, 0.8588235f);
        public static readonly Colour MediumSeaGreen = new Colour(0.2352941f, 0.7019608f, 0.4431373f);
        public static readonly Colour MediumSlateBlue = new Colour(0.4823529f, 0.4078431f, 0.9333333f);
        public static readonly Colour MediumSpringGreen = new Colour(0f, 0.9803922f, 0.6039216f);
        public static readonly Colour MediumTurquoise = new Colour(0.282353f, 0.8196079f, 0.8f);
        public static readonly Colour MediumVioletRed = new Colour(0.7803922f, 0.08235294f, 0.5215687f);
        public static readonly Colour MidnightBlue = new Colour(0.09803922f, 0.09803922f, 0.4392157f);
        public static readonly Colour MintCream = new Colour(0.9607843f, 1f, 0.9803922f);
        public static readonly Colour MistyRose = new Colour(1f, 0.8941177f, 0.8823529f);
        public static readonly Colour Moccasin = new Colour(1f, 0.8941177f, 0.7098039f);
        public static readonly Colour NavajoWhite = new Colour(1f, 0.8705882f, 0.6784314f);
        public static readonly Colour Navy = new Colour(0f, 0f, 0.5019608f);
        public static readonly Colour OldLace = new Colour(0.9921569f, 0.9607843f, 0.9019608f);
        public static readonly Colour Olive = new Colour(0.5019608f, 0.5019608f, 0f);
        public static readonly Colour OliveDrab = new Colour(0.4196078f, 0.5568628f, 0.1372549f);
        public static readonly Colour Orange = new Colour(1f, 0.6470588f, 0f);
        public static readonly Colour OrangeRed = new Colour(1f, 0.2705882f, 0f);
        public static readonly Colour Orchid = new Colour(0.854902f, 0.4392157f, 0.8392157f);
        public static readonly Colour PaleGoldenrod = new Colour(0.9333333f, 0.9098039f, 0.6666667f);
        public static readonly Colour PaleGreen = new Colour(0.5960785f, 0.9843137f, 0.5960785f);
        public static readonly Colour PaleTurquoise = new Colour(0.6862745f, 0.9333333f, 0.9333333f);
        public static readonly Colour PaleVioletRed = new Colour(0.8588235f, 0.4392157f, 0.5764706f);
        public static readonly Colour PapayaWhip = new Colour(1f, 0.9372549f, 0.8352941f);
        public static readonly Colour PeachPuff = new Colour(1f, 0.854902f, 0.7254902f);
        public static readonly Colour Peru = new Colour(0.8039216f, 0.5215687f, 0.2470588f);
        public static readonly Colour Pink = new Colour(1f, 0.7529412f, 0.7960784f);
        public static readonly Colour Plum = new Colour(0.8666667f, 0.627451f, 0.8666667f);
        public static readonly Colour PowderBlue = new Colour(0.6901961f, 0.8784314f, 0.9019608f);
        public static readonly Colour Purple = new Colour(0.5019608f, 0f, 0.5019608f);
        public static readonly Colour RebeccaPurple = new Colour(0.4f, 0.2f, 0.6f);
        public static readonly Colour PureRed = new Colour(1f, 0f, 0f);
        public static readonly Colour RosyBrown = new Colour(0.7372549f, 0.5607843f, 0.5607843f);
        public static readonly Colour RoyalBlue = new Colour(0.254902f, 0.4117647f, 0.8823529f);
        public static readonly Colour SaddleBrown = new Colour(0.5450981f, 0.2705882f, 0.07450981f);
        public static readonly Colour Salmon = new Colour(0.9803922f, 0.5019608f, 0.4470588f);
        public static readonly Colour SandyBrown = new Colour(0.9568627f, 0.6431373f, 0.3764706f);
        public static readonly Colour SeaGreen = new Colour(0.1803922f, 0.5450981f, 0.3411765f);
        public static readonly Colour Seashell = new Colour(1f, 0.9607843f, 0.9333333f);
        public static readonly Colour Sienna = new Colour(0.627451f, 0.3215686f, 0.1764706f);
        public static readonly Colour Silver = new Colour(0.7529412f, 0.7529412f, 0.7529412f);
        public static readonly Colour SkyBlue = new Colour(0.5294118f, 0.8078431f, 0.9215686f);
        public static readonly Colour SlateBlue = new Colour(0.4156863f, 0.3529412f, 0.8039216f);
        public static readonly Colour Snow = new Colour(1f, 0.9803922f, 0.9803922f);
        public static readonly Colour SpringGreen = new Colour(0f, 1f, 0.4980392f);
        public static readonly Colour SteelBlue = new Colour(0.2745098f, 0.509804f, 0.7058824f);
        public static readonly Colour Tan = new Colour(0.8235294f, 0.7058824f, 0.5490196f);
        public static readonly Colour Teal = new Colour(0f, 0.5019608f, 0.5019608f);
        public static readonly Colour Thistle = new Colour(0.8470588f, 0.7490196f, 0.8470588f);
        public static readonly Colour Tomato = new Colour(1f, 0.3882353f, 0.2784314f);
        public static readonly Colour Transparent = new Colour(1f, 0f, 0f, 0f);
        public static readonly Colour Turquoise = new Colour(0.2509804f, 0.8784314f, 0.8156863f);
        public static readonly Colour Violet = new Colour(0.9333333f, 0.509804f, 0.9333333f);
        public static readonly Colour Wheat = new Colour(0.9607843f, 0.8705882f, 0.7019608f);
        public static readonly Colour White = new Colour(1f, 1f, 1f);
        public static readonly Colour WhiteSmoke = new Colour(0.9607843f, 0.9607843f, 0.9607843f);
        public static readonly Colour Yellow = new Colour(1f, 1f, 0f);
        public static readonly Colour YellowGreen = new Colour(0.6039216f, 0.8039216f, 0.1960784f);
        #endregion

    }
}
