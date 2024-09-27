using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Animations;

public abstract class PlayableSampleBase : MonoBehaviour
{

    #region PROTECTED ATTRIBUTES

    protected Animator _animator = null;

    protected PlayableGraph _playableGraph;
    protected AnimationPlayableOutput _playableOutput;

    #endregion

    #region CREATION AND DESTRUCTION

    protected virtual void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    protected virtual void OnEnable()
    {
        if (!_playableGraph.IsValid())
        {
            _playableGraph = PlayableGraph.Create();
            _playableOutput = AnimationPlayableOutput.Create(_playableGraph, "Animation", _animator);

            InitPlayableGraph();
        }

       StartPlayableGraph();
    }

    protected abstract void InitPlayableGraph();

    protected virtual void OnDisable()
    {
        StopPlayableGraph();
    }

    protected virtual void OnDestroy()
    {
        // Destroys all Playables and Outputs created by the graph.
        if (_playableGraph.IsValid())
        {
            _playableGraph.Destroy();
        }
    }

    #endregion

    #region GET AND SET

    public virtual void StartPlayableGraph()
    {
        if (_playableGraph.IsValid() && !_playableGraph.IsPlaying())
        {
            _playableGraph.Play();
        }
    }

    public virtual void StopPlayableGraph()
    {
        if (_playableGraph.IsValid() && _playableGraph.IsPlaying())
        {
            _playableGraph.Stop();
        }
    }

    public virtual void SetTimeUpdateMode(DirectorUpdateMode updateMode)
    {
        if (_playableGraph.IsValid())
        {
            _playableGraph.SetTimeUpdateMode(updateMode);
        }
    }

    #endregion

    #region UPDATE

    public virtual void Evaluate(float deltaTime)
    {
        if (_playableGraph.IsValid() && _playableGraph.IsPlaying())
        {
            _playableGraph.Evaluate(deltaTime);
        }
    }

    #endregion

}
