using ObservableKT._Source.DayCycle;
using ObservableKT._Source.DayCycle.SkyLogic;
using ObservableKT._Source.DayCycle.StarLogic;
using ObservableKT._Source.DayCycle.SunLogic;
using UnityEngine;

namespace ObservableKT._Source.Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private Cycle cycle;
        [SerializeField] private SunView sunView;
        [SerializeField] private StarView[] starViews;
        [SerializeField] private SkyView skyView;
        
        private Sun _sun;
        private Star _star;
        private Sky _sky;
        
        private void Awake()
        {
            _sun = new Sun(cycle);
            _star = new Star(cycle);
            _sky = new Sky(cycle);
            
            sunView.Init(_sun);
            skyView.Init(_sky);
            
            foreach (var starView in starViews)
                starView.Init(_star);
        }
    }
}