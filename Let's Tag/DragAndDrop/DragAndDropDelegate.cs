/******************************************************************************
 *
 *  This file is based on sample code found on the internet.
 *  Original author unknown.
 *
 *  Source:
 *  http://riqueliam.blog.51cto.com/466137/107612
 *
 *****************************************************************************/

using System.Windows.Forms;

namespace LetsTag.DragAndDrop
{
    public class DragAndDropDelegate
    {
        Control dragSourceControl;
        DataObject dataObject;

        QueryContinueDragEventHandler queryContinueDragEventHandler;

        public DragAndDropDelegate(Control dragSourceControl, DataObject dataObject, DragDropEffects allowedEffects)
        {
            this.dragSourceControl = dragSourceControl;
            this.dataObject = dataObject;

            queryContinueDragEventHandler = new QueryContinueDragEventHandler(HandleQueryContinueDrag);
            dragSourceControl.QueryContinueDrag += queryContinueDragEventHandler;
            dragSourceControl.DoDragDrop(dataObject, allowedEffects);
        }

        private void HandleQueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {
            bool endDrag = false;

            if (e.EscapePressed)
            {
                // ESC pressed
                e.Action = DragAction.Cancel;
                endDrag = true;
            }
            else if (e.KeyState == 0)
            {
                // Drop
                dataObject.SetData(ShellClipboardFormats.CFSTR_INDRAGLOOP, 0);
                e.Action = DragAction.Drop;
                endDrag = true;
            }

            if (endDrag)
            {
                dragSourceControl.QueryContinueDrag -= queryContinueDragEventHandler;
                return;
            }

            e.Action = DragAction.Continue;
        }
    }
}
