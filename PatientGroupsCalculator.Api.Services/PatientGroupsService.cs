using PatientGroupsCalculator.Api.Contracts.Interfaces;
using PatientGroupsCalculator.Api.Contracts.Models;

namespace PatientGroupsCalculator.Api.Services
{
    public class PatientGroupsService : IPatientGroupsService
    {

        private void DFS(int[][] M, int i, int j, int ROW, int COL)
        {

            if (i < 0 || j < 0 || i > (ROW - 1) || j > (COL - 1) || M[i][j] != 1)
            {
                return;
            }

            if (M[i][j] == 1)
            {
                M[i][j] = 0;
                DFS(M, i + 1, j, ROW, COL);     
                DFS(M, i - 1, j, ROW, COL);    
                DFS(M, i, j + 1, ROW, COL);     
                DFS(M, i, j - 1, ROW, COL);     
                DFS(M, i + 1, j + 1, ROW, COL); 
                DFS(M, i - 1, j - 1, ROW, COL); 
                DFS(M, i + 1, j - 1, ROW, COL); 
                DFS(M, i - 1, j + 1, ROW, COL); 
            }
        }

        public Result<int> countPatientGroups(int[][] M)
        {
            int ROW = M.GetLength(0);
            int COL = M[0].GetLength(0);
            int count = 0;
            for (int i = 0; i < ROW; i++)
            {
                for (int j = 0; j < COL; j++)
                {
                    if (M[i][j] == 1)
                    {
                        M[i][j] = 0;
                        count++;
                        DFS(M, i + 1, j, ROW, COL);    
                        DFS(M, i - 1, j, ROW, COL);     
                        DFS(M, i, j + 1, ROW, COL);     
                        DFS(M, i, j - 1, ROW, COL);    
                        DFS(M, i + 1, j + 1, ROW, COL);
                        DFS(M, i - 1, j - 1, ROW, COL); 
                        DFS(M, i + 1, j - 1, ROW, COL); 
                        DFS(M, i - 1, j + 1, ROW, COL); 
                    }
                }
            }
            return new Result<int> { NumberOfGroups  = count, ResultCode = ResultCode.Ok };
        }
    }
}
