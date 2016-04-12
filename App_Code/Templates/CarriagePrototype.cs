﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

/// <summary>
/// Summary description for CarriagePrototype
/// </summary>
/// 
[Serializable]
public abstract class CarriagePrototype
{
    //Carriage carriage;
    public Panel panel;
    public List<Button> buttons = new List<Button>();

    public CarriagePrototype()
    {
        //this.carriage = carriage;
        this.panel = new Panel();
    }

    public void CheckFreePlaces(Carriage carriage)
    {
        foreach (Place place in carriage.places)
        {
            if (!place.IsFree)
            {
                FindPlace(place.num);
            }
        }
    }

    /*private void FindPlace(int num, Control control)
    {
        foreach (Control c in control.Controls)
        {
            if (c.GetType() == typeof(Button))
            {
                //if (Convert.ToInt32(((Button)c).ID[((Button)c).ID.Length - 1]) == num)
                if (Convert.ToInt32(((Button)c).Text) == num)
                {
                    ((Button)c).CssClass = "closed";
                    //((Button)c).Enabled = false;
                }
            }
            else
                FindPlace(num, c);
        }
    }*/

    private void FindPlace(int num)
    {
        foreach(Button but in buttons)
        {
            if(Convert.ToInt32(but.Text) == num)
            {
                but.CssClass = "closed";
                break;
            }
        }
    }

    public CarriagePrototype Clone()
    {
        using (var ms = new MemoryStream())
        {
            var formatter = new BinaryFormatter();
            formatter.Serialize(ms, this);
            ms.Position = 0;

            return (CarriagePrototype)formatter.Deserialize(ms);
        }
    }
}

[Serializable]
class CarriageReserved : CarriagePrototype
{
    public CarriageReserved(int carrId)
    {
        for(int i = 1; i < 37; i += 2)
        {
            Button place = new Button
            {
                Text = i.ToString(),
                CssClass = "PlaceReservedA",
                CausesValidation = false,
                ID = "place_" + i.ToString() + "_" + carrId
            };
            buttons.Add(place);
            panel.Controls.Add(place);
            if (i % 4 == 1) panel.Controls.Add(
                new Button {
                    Text = "",
                    CssClass = "PlaceReservedA",
                    CausesValidation = false,
            });
            //if (i % 4 == 1) panel.Controls.Add(new Panel { Width = 40, Height = 40 });
        }

        panel.Controls.Add(new Literal { Text = "<br />" });

        for (int i = 2; i < 37; i += 2)
        {
            Button place = new Button
            {
                Text = i.ToString(),
                CssClass = "PlaceReservedA",
                CausesValidation = false,
                ID = "place_" + i.ToString() + "_" + carrId
            };
            buttons.Add(place);
            panel.Controls.Add(place);
            if (i % 4 == 2) panel.Controls.Add(
                new Button
                {
                    Text = "",
                    CssClass = "PlaceReservedA",
                    CausesValidation = false,
                });
        }

        panel.Controls.Add(new Literal { Text = "<br />" });
        panel.Controls.Add(new Literal { Text = "<br />" });

        for (int i = 54; i > 36; i -= 1)
        {
            Button place = new Button
            {
                Text = i.ToString(),
                CssClass = "PlaceReservedB",
                CausesValidation = false,
                ID = "place_" + i.ToString() + "_" + carrId
            };
            buttons.Add(place);
            panel.Controls.Add(place);
        }
    }
}

[Serializable]
class CarriageCoupe : CarriagePrototype
{
    public CarriageCoupe()
    {
        for (int i = 1; i < 37; i++)
        {
            Button place = new Button
            {
                Text = i.ToString(),
                CssClass = "PlaceCoupe",
                CausesValidation = false
                //ID = "place_" + i.ToString()
            };
            //place.Click += Place_Click;
            buttons.Add(place);
            //panel.Controls.Add(place);
        }
    }
}

[Serializable]
class CarriageLux : CarriagePrototype
{
    public CarriageLux()
    {
        for (int i = 1; i < 21; i++)
        {
            Button place = new Button
            {
                Text = i.ToString(),
                CssClass = "PlaceLux",
                CausesValidation = false
                //ID = "place_" + i.ToString()
            };
            //place.Click += Place_Click;
            buttons.Add(place);
            //panel.Controls.Add(place);
        }
    }
}

public class PrototypeManager
{
    //private static Hashtable carriagesMap = new Hashtable();

    public static CarriagePrototype GetCarriage(char carrCode, Carriage current)
    {
        //CarriagePrototype carr = (CarriagePrototype)carriagesMap[carrCode];
        //carr.CheckFreePlaces(current);
        //return carr.Clone();

        CarriagePrototype carr = null;
        switch (carrCode)
        {
            case 'r':
                carr = new CarriageReserved(current.Id);
                break;
            case 'c':
                carr = new CarriageCoupe();
                break;
            case 'l':
                carr = new CarriageLux();
                break;
        }
        carr.CheckFreePlaces(current);
        return carr;
    }

    static PrototypeManager()
    {
        //CarriageReserved cr = new CarriageReserved();
        //carriagesMap["reserved"] = cr;
        //carriagesMap['r'] = cr;
        //CarriageCoupe cc = new CarriageCoupe();
        //carriagesMap["coupe"] = cc;
        //carriagesMap['c'] = cc;
        //CarriageLux cl = new CarriageLux();
        ////carriagesMap["lux"] = cl;
        //carriagesMap['l'] = cl;
    }
}