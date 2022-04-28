import { Typography } from '@mui/material'
import React from 'react'
import { useParams } from 'react-router-dom';

function PhoneDetail(props) {
  const {id} = useParams();
  return (
    <div>
      <Typography variant='h4'>Phone Details</Typography>
      {id}
    </div>
  )
}

export default PhoneDetail