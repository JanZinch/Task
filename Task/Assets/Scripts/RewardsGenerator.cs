using UnityEngine;

static class RewardsGenerator
{
    public static int? Generate(SlotNumber slotNumber) {

        int chance, result;

        if (slotNumber == SlotNumber.ONE)
        {          
            if (Random.Range(1, 3) == 1) {

                result = 1;
            }
            else {

                chance = Random.Range(1, 11);

                if (chance <= 1)
                {
                    result = 5;
                }
                else
                {
                    result = Random.Range(2, 5);
                }
            }

            return result;
        }
        else if (slotNumber == SlotNumber.TWO)
        {
            chance = Random.Range(1, 11);

            if (chance <= 1)
            {
                result = 9;
            }
            else { 
            
                result = Random.Range(6, 9);
            }

            return result;
        }
        else {

            return null;
        } 
    }


}

