using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class EquipmentBag
    {
        public List<AparatInBag> AparatyEquippped { get; set; } = new List<AparatInBag>();
        public List<ObiektywtInBag> ObiektywyEquipped { get; set; } = new List<ObiektywtInBag>();
        public void RemoveAparat(int index)
        {
            if (index >= 0 && index < AparatBagSize()) AparatyEquippped.RemoveAt(index);
        }
        public void RemoveObiektyw(int index)
        {
            if (index >= 0 && index < ObiektywBagSize()) ObiektywyEquipped.RemoveAt(index);
        }
        public bool AddAparat(AparatViewModel aparat)
        {
            if (aparat == null)
                return false;

            int index = AparatyEquippped.FindIndex(m => m.Aparat.Id == aparat.Id);
            if (index < 0)
                AparatyEquippped.Add(new AparatInBag()
                { Aparat = aparat, AparatAmount = 1 });
            else
                AparatyEquippped[index].AparatAmount++;
            return true;
        }
        public bool AddObiektyw(ObiektywViewModel obiektyw)
        {
            if (obiektyw == null)
                return false;

            int index = ObiektywyEquipped.FindIndex(n => n.Obiektyw.Id == obiektyw.Id);
            if (index < 0)
                ObiektywyEquipped.Add(new ObiektywtInBag()
                { Obiektyw = obiektyw, ObiektywAmount = 1 });
            else
                ObiektywyEquipped[index].ObiektywAmount++;
            return true;
        }

        public int AparatBagSize()
        {
            return AparatyEquippped.Count;
        }
        public int ObiektywBagSize()
        {
            return ObiektywyEquipped.Count;
        }
        public double TotalAmount()
        {
            double sum = 0;
            foreach (AparatInBag equipment in AparatyEquippped)
                sum += equipment.AparatAmount;
            foreach (ObiektywtInBag equipment in ObiektywyEquipped)
                sum += equipment.ObiektywAmount;
            return sum;
        }
        public double TotalWeight()
        {
            double sum = 0;
            foreach (AparatInBag equipment in AparatyEquippped)
                if (equipment.Aparat != null)
                {
                    sum += equipment.AparatAmount * equipment.Aparat.Waga;
                }
            foreach (ObiektywtInBag equipment in ObiektywyEquipped)
                if (equipment.Obiektyw != null)
                {
                    sum += equipment.ObiektywAmount * equipment.Obiektyw.Waga;
                }

            return sum;
        }
    }
}

