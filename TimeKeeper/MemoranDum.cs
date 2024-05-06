using ExcelDataReader;
using OfficeOpenXml;

namespace TimeKeeper;
using System.IO;
public class MemoranDum
{ 
    /***
   * 任务清单添加方法
   */
    private string eventName;
    private int targetTime;
    private const string ExcelFilePath = "events.xlsx";
    public void AddEvent(string eventName,int targetTime)
    {
        
    }
/***
 * 任务清单添加菜单
 * 输入任务名
 * 任务时常
 * 如背单词30min
 * 记录到excal表格中
 */
    public void AddEventMenu()
    {
        using (var package = new ExcelPackage(new FileInfo(ExcelFilePath)))
        {
            ExcelWorksheet worksheet = package.Workbook.Worksheets["Events"];
            int rowCount = worksheet.Dimension.Rows;

            worksheet.Cells[rowCount + 1, 1].Value = eventName;
            worksheet.Cells[rowCount + 1, 2].Value = targetTime;

            package.Save();
        }
        Console.WriteLine("事件已添加到 Excel 文件中。");
    }

    /***
     * 任务调用方法
     * 打印并输出任务清单所有任务以及剩余时常
     * 输入任务名开始执行倒计时
     * 倒计时为一个后台线程
     * 选择结束任务时会将剩余时间覆盖到excal相应位置，表示时间已经过去这么久
     *
     */
    public void EventCountdown()
    {
        using (var stream = File.Open(ExcelFilePath,FileMode.Open,FileAccess.Read) )
        {
            using (var reader =ExcelReaderFactory.CreateReader(stream))
            {
                while (reader.Read())
                {
                    
                }
            }
        }
    }
}
