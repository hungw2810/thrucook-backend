using Thucook.Commons.Enums;

namespace Thucook.Commons.Constants
{
    public static class PropertyConstants
    {
        /// <summary>
        /// Value type in same group can be convert to each other
        /// </summary>
        public static readonly short[][] ValueTypeGroups = new short[][]
        {
            new short[] { (short)PropertyValueTypeEnum.FreeText, (short)PropertyValueTypeEnum.ListOfOptions },
            new short[] { (short)PropertyValueTypeEnum.Date, (short)PropertyValueTypeEnum.DateTime },
        };
    }
}
