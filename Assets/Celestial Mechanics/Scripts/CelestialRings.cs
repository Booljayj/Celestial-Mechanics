﻿using UnityEngine;
using System.Collections;

namespace CelestialMechanics {
	[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
	public class CelestialRings : MonoBehaviour {
		[SerializeField] float innerRadius;
		[SerializeField] float outerRadius;
		[Range(3,50), SerializeField] int segments;

		void Reset() {
			innerRadius = 1f;
			outerRadius = 1.5f;
			segments = 10;
		}

		void OnValidate() {
			if (innerRadius < 0) innerRadius = 0f;
			if (outerRadius < 0) outerRadius = 0f;
			Generate();
		}

		public void Generate() {
			MeshFilter filter = GetComponent<MeshFilter>();
			DestroyImmediate(filter.sharedMesh);
			filter.sharedMesh = Kepler.GenerateRingMesh(innerRadius, outerRadius, segments);
		}
	}
}