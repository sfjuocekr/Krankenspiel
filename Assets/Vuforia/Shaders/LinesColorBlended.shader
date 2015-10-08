Shader "Lines/Colored Blended" {
	Properties {
		_LineColor ("Line Color", Color) = (0, 1, 0, 1)
	}

	SubShader {
		Pass {
			Color [_LineColor]
		}
	}
}