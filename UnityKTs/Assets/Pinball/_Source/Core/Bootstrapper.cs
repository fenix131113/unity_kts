using Pinball.Interactable;
using Pinball.Player;
using Pinball.Player.View;
using UnityEngine;

namespace Pinball.Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private BallThrower ballThrower;
        [SerializeField] private ThrowPowerView throwView;
        [SerializeField] private Flipper rightFlipper;
        [SerializeField] private Flipper leftFlipper;
        [SerializeField] private DeadZone deadZone;
        [SerializeField] private GameRestarter gameRestarter;
        [SerializeField] private ScoresView scoresView;
        [SerializeField] private BonusSpawner bonusSpawner;
        [SerializeField] private AScoresGiver[] scoreGivers;

        private readonly Scores _scores = new();

        private void Awake()
        {
            scoresView.Construct(_scores);
            gameRestarter.Construct(playerInput);
            ballThrower.Construct(playerInput, deadZone);
            throwView.Construct(ballThrower);
            bonusSpawner.Construct(_scores);
            
            rightFlipper.Construct(playerInput);
            leftFlipper.Construct(playerInput);

            foreach (var giver in scoreGivers)
                giver.InitScores(_scores);
        }
    }
}