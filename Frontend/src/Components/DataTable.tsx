import * as React from 'react';
import { DataGrid, GridColDef, GridPaginationModel } from '@mui/x-data-grid';
import Paper from '@mui/material/Paper';

interface Props
{
  paginationModel:GridPaginationModel
  rows:any[],
  columns:GridColDef[],
}

export default function DataTable({paginationModel,rows,columns}:Props) {
  
    return (
        <Paper sx={{ height: 400, width: '100%' }}>
          <DataGrid
            rows={rows}
            columns={columns}
            initialState={{ pagination: { paginationModel } }}
            pageSizeOptions={[5, 10]}
            sx={{ border: 0 }}
          />
        </Paper>
      );

  }
  