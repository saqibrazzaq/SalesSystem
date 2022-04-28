import { Typography } from '@mui/material'
import React from 'react'
import PhoneBoxList from '../../Components/PhoneBoxList/PhoneBoxList'

function Products() {
  return (
    <div>
      <Typography variant="h4" sx={{pb: 4}}>Products</Typography>

      <PhoneBoxList />
    </div>
  )
}

export default Products