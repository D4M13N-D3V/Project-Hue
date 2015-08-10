
Shader "Transparent/Cutout/Diffuse Tint" {


Properties {


    _Color ("Main Color", Color) = (1,1,1,1)


    

    _MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}


    _Mask ("Mask (RGB) Trans (A)", 2D) = "white" {}

 

    _Cutoff ("Alpha cutoff", Range(0,1)) = 0.0


    _SWColor1 ("Swap to 1", Color) = (1.00,1.00,1.00,0.5)


    _SWColor2 ("Swap to 2", Color) = (0.75,0.75,0.75,0.5)


    _SWColor3 ("Swap to 3", Color) = (0.50,0.50,0.50,0.5)


    _SWColor4 ("Swap to 4", Color) = (0.25,0.25,0.25,0.5)


}


 


SubShader {


    Tags {"IgnoreProjector"="True" "RenderType"="TransparentCutout"}


    LOD 600


    


CGPROGRAM


#pragma surface surf BlinnPhong alphatest:_Cutoff

//#pragma target 3.0

 


sampler2D _MainTex;


sampler2D _Mask;


 


float4 _Color;


float3 _SWColor1;


float3 _SWColor2;


float3 _SWColor3;


float3 _SWColor4;


 


    


struct Input {


    float2 uv_MainTex;


};


 


void surf (Input IN, inout SurfaceOutput o) {


 


    half4 base = tex2D(_MainTex, IN.uv_MainTex) * _Color;


    half4 mask = tex2D(_Mask, IN.uv_MainTex);


 


    half3 col = base.rgb*(  (mask.r>=0.900)? _SWColor1.rgb :


                            (mask.r>=0.650)? _SWColor2.rgb :


                            (mask.r>=0.400)? _SWColor3.rgb :


                            (mask.r>=0.150)? _SWColor4.rgb :


                            half3(1,1,1)


                        );

    


    o.Albedo = col.rgb;


    o.Alpha = base.a;


}


 


ENDCG


}


 


Fallback "Transparent/Cutout/Diffuse"


}


 
