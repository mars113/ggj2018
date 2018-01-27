﻿using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class AnimateManager : MonoBehaviour, IAnimateManager
{
    private IBusView _busView;
    private IBusViewFactory _busViewFactory;

    public AnimateManager() {
        _busViewFactory = new BusViewFactory();
    }

    public void PlayBusAnimate(IBus bus) {

        Debug.Log("Play animate");

        StartCoroutine(_playBusAnimate(bus));
    }

    private IEnumerator _playBusAnimate(IBus bus) {

        List<IStation> stations = bus.BusPath;

        _busView = _busViewFactory.MakeBusView();

		yield return _busView.InitAnimate(stations[0].Transform.position); 

        for (int i = 1; i < stations.Count; i++) {
			var road = stations [i - 1].GetRoad (stations[i]);
			yield return _busView.MoveToStationAnimate(road);
        }

        yield return null;
    }
}