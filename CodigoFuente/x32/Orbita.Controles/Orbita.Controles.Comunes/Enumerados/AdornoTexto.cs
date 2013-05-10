//***********************************************************************
// Assembly         : Orbita.Controles.Comunes
// Author           : crodriguez
// Created          : 19-01-2012
//
// Last Modified By : crodriguez
// Last Modified On : 19-01-2012
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
namespace Orbita.Controles.Comunes
{
    /// <summary>
    /// AdornoTexto.
    /// </summary>
    public enum AdornoTexto
    {
        Ninguno = Infragistics.Win.TextTrimming.Default,
        Caracter = Infragistics.Win.TextTrimming.Character,
        CaracterEliptico = Infragistics.Win.TextTrimming.EllipsisCharacter,
        RutaEliptica = Infragistics.Win.TextTrimming.EllipsisPath,
        PalabraEliptica = Infragistics.Win.TextTrimming.EllipsisWord,
        Palabra = Infragistics.Win.TextTrimming.Word,
        SinLineaLimite = Infragistics.Win.TextTrimming.NoneWithLineLimit,
        CaracterConLineaLimite = Infragistics.Win.TextTrimming.CharacterWithLineLimit,
        CaracterElipticoConLineaLimite = Infragistics.Win.TextTrimming.EllipsisCharacterWithLineLimit,
        RutaElipticaConLineaLimite = Infragistics.Win.TextTrimming.EllipsisPathWithLineLimit,
        PalabraElipticaConLineaLimite = Infragistics.Win.TextTrimming.EllipsisWordWithLineLimit,
        PalabraConLineaLimite = Infragistics.Win.TextTrimming.WordWithLineLimit
    }
}