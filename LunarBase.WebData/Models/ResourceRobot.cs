using System;
using System.Collections.Generic;

namespace LunarBase.WebData.Models
{
    public class ResourceRobot
    {
        private int bonusPersent;
        private Random rand = new Random();

        public ResourceRobot() : this(0)
        { 
        }

        public ResourceRobot(int bonusPersent)
        {
            this.bonusPersent = bonusPersent;
        }

        public bool SearchingResource(List<ResourceInBuilding> findedResources, List<ResourceInBuilding> resources, out ResourceInBuilding foundResource)
        {
            bool isFind = false;
            int persent = bonusPersent;        

            switch(findedResources.Count)
            {
                case 0:
                    persent += 90; 
                    break;
                case 1:
                    persent += 60; 
                    break;
                case 2:
                    persent += 30; 
                    break;
                case 3:
                    persent += 25; 
                    break;
                case 4:
                    persent += 30; 
                    break;
                case 5:
                    persent += 15; 
                    break;
                default:
                    persent += 10;
                    break;
            }
        
            isFind = FindResource(persent);
            if (isFind)
            {
                foundResource = ChooseResource(findedResources, resources);
            }
            else
            {
                foundResource = null;
            }

            return isFind;
        }

        private bool FindResource(int persent)
        {
            int randomNumber = rand.Next(1, 101);
            bool isFind = false;
            if (randomNumber <= persent)
            {
                isFind = true;
            }

            return isFind;
        }

        private ResourceInBuilding ChooseResource(List<ResourceInBuilding> findedResources, List<ResourceInBuilding> resources)
        {
            int randomNumber = rand.Next(0, 2);
            ResourceInBuilding choosenResource;
            if (findedResources.Count == 0)
            {
                choosenResource = ChooseNewResource(resources);
            }

            if (randomNumber == 0)
            {
                choosenResource = ChooseNewResource(resources);
            }
            else
            {
                choosenResource = ChooseNewResource(findedResources);
            }

            return choosenResource; //TODO dali findedResources shte pazi samo po edin pat imenata na namerenite resursi ili vseki pat shte se dobavq resursa
        }

        private ResourceInBuilding ChooseNewResource(List<ResourceInBuilding> resources)
        {
            int randomNumber = rand.Next(0, resources.Count);
            return resources[randomNumber];
        }
    }
}
