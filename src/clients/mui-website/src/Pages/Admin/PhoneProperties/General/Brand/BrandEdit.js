import { Typography } from '@mui/material';
import React from 'react'
import { useParams } from 'react-router-dom'

function BrandEdit() {
  // Get id from url param
  let {id} = useParams();
  // Edit or add new button
  const btnAddUpdate = id ? "Edit Brand" : "Add New Brand";
  return (
    <>
      <Typography variant='h6'>{btnAddUpdate}</Typography>
    </>
  )
}

export default BrandEdit