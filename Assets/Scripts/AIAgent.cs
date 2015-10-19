using UnityEngine;
using System.Collections;
using Behave.Runtime;
using Tree = Behave.Runtime.Tree;

public class AIAgent : MonoBehaviour, IAgent {
    Tree m_Tree;
	
	//Dette er grundstenen i Behave. I stedet for BLNewBehaveLibrary, skriver man sit eget navn



    IEnumerator Start() {
        m_Tree = BLNewBehaveLibrary0.InstantiateTree(
            BLNewBehaveLibrary0.TreeType.HeroAI1_NewTree1, this);
        while (Application.isPlaying && m_Tree != null) 
        {
            yield return new WaitForSeconds(1 / m_Tree.Frequency);
            AIUpdate();

        }
            
    }

    void AIUpdate() {
        m_Tree.Tick();
    }

    public BehaveResult Tick(Tree sender, bool init)
    {
        Debug.Log("Ticked Received by unhandled " +
        (BLNewBehaveLibrary0.IsAction(sender.ActiveID) ? "Action " :
        "Decorator ") +
        " ... " + (BLNewBehaveLibrary0.IsAction(sender.ActiveID) ?
        ((BLNewBehaveLibrary0.ActionType)sender.ActiveID).ToString() :
        ((BLNewBehaveLibrary0.DecoratorType)sender.ActiveID).ToString()));
        return BehaveResult.Success;
    }

    public void Reset(Tree sender) {

    }

    public int SelectTopPriority(Tree sender, params int [] IDs) {
        return 0;
    }

    // For at aktivere et Leaf i et Behavior Tree skal man bruge følgende syntax:
    // BehaveResult Tick[navn på Leaf]Action(Tree sender){}
    // For at aktivere decorator:
    // BehaveResult Tick[navn på Decorator]Decorator(Tree sender){}
    // Ved Sequences, paralels og selectors skal man blot skrive til leaves i actionen.

    //-------------------------------------------------------------------- Alt under denne linje er specifikt for Dette spil ----------------------------------------------------------


}
