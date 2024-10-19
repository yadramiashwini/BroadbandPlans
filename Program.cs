using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;

namespace BroadbandPlans
{
    interface IBroadbandPlan       //creating interface
    {
        int GetBroadbandPlanAmount();
    }
    class Black : IBroadbandPlan          //Black class implementing IbroadPlan
    {
        private bool _isSubscriptionValid { get; }

        private int _discountPercentage { get; }

        private const int PlanAmount = 3000;

        public Black(bool isSubscriptionValid, int discountPercentage)   //constructor initializing values
        {
            this._isSubscriptionValid = isSubscriptionValid;
            this._discountPercentage = discountPercentage;
            if (_discountPercentage < 0 && _discountPercentage > 50)
            {
                throw new ArgumentOutOfRangeException();

            }
        }
        public int GetBroadbandPlanAmount()               //implementing interface method
        {
            if (_isSubscriptionValid)
            {
                return _discountPercentage;
            }
            return PlanAmount;
        }

        class Gold : IBroadbandPlan                 //gold class implementing IbroadbandPlan
        {
            private bool _isSubscriptionValid { get; }
            private int _discountPercentage { get; }

            private const int PlanAmount = 1500;

            public Gold(bool isSubscriptionValid, int discountPercentage)   //gold class Constructor
            {
                this._isSubscriptionValid= isSubscriptionValid;
                this._discountPercentage = discountPercentage;
                if(_discountPercentage<0 && _discountPercentage > 30)
                {
                    throw new ArgumentOutOfRangeException();
                }

            }
            public int GetBroadbandPlanAmount()         //implementing interface method
            {
                if (_isSubscriptionValid)
                {
                    return (_discountPercentage*PlanAmount/100);   
                }
                return PlanAmount;
            }
            class SubscribePlan             //defining subsribeplan
            {
                private IList<IBroadbandPlan> _broadbandPlans { get; }
               

                public SubscribePlan(IList<IBroadbandPlan> broadbandPlans)
                {
                    this._broadbandPlans = broadbandPlans;
                    if (broadbandPlans == null)
                    {
                        throw new ArgumentNullException();
                    }

                }
                public IList<Tuple<string, int>> GetSubscriptionPlan() 
                { 
                    
                    if(_broadbandPlans == null)
                    {
                        throw new ArgumentNullException();             //exception handlying
                    }
                    return GetSubscriptionPlan();   
                }

                static void Main(string[] args)
                {
                    
                    var plans =  new List<IBroadbandPlan>();         //creating list
                    {
                        new Black(true, 50);
                        new Black(false, 10);
                        new Gold(true, 30);
                        new Black(false, 20);
                        new Gold(false, 20);

                    }
                    
                    var subscriptionPlans = new SubscribePlan(plans);            //instance creation
                    
                    var result = subscriptionPlans.GetSubscriptionPlan();
                    foreach (var item in result)
                    {
                        Console.WriteLine($"{item.Item1},{item.Item2}");
                    }
                }
            }
        }
    }
}
