using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;

namespace autocad02
{
    public class Commands
    {
        /// <summary>
        /// 라인을 그리기 샘플
        /// </summary>
        [CommandMethod("DLC")]
        public static void DrawLineCurve()
        {
            var document = Application.DocumentManager.MdiActiveDocument;
            var database = document.Database;
            using (var transaction = database.TransactionManager.StartTransaction())
            {
                var blockTableRecord = (BlockTableRecord)transaction.GetObject(database.CurrentSpaceId, OpenMode.ForWrite);
                var line = new Line(new Point3d(0, 0, 0), new Point3d(100, 100, 0));
                blockTableRecord.AppendEntity(line);
                transaction.Commit();
            }
        }
    }
}