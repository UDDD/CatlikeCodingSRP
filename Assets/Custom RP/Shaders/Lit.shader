Shader "Custom RP/Lit"
{
    Properties
    {
        _BaseMap("Texture", 2D) = "white" {}
        _BaseColor("Color", Color) = (0.5, 0.5, 0.5, 1.0)
        _Cutoff("Alpha Cutoff", Range(0, 1)) = 0.5
        [Toggle(_CLIPPING)] _Clipping ("Alpha Clipping", Float) = 0
        [Enum(UnityEngine.Rendering.BlendMode)] _SrcBlend("Src Blend", Float) = 1
        [Enum(UnityEngine.Rendering.BlendMode)] _DstBlend("Dst Blend", Float) = 0
        [Enum(Off, 0, On, 4)] _Zwrite("ZWrite", Float) = 1
    }
    SubShader
    {
        Pass
        {
            Blend [_SrcBlend] [_DstBlend]
            ZWrite [_Zwrite]

            HLSLPROGRAM
            #pragma shader_feature _CLIPPING
            #pragma multi_compile_instancing
            #pragma vertex LitPassVertex
            #pragma fragment LitPassFragment
            #include "LitPass.hlsl"
            ENDHLSL
        }
    }
}