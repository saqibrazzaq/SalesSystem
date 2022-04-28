import React from 'react'
import Typography from "@mui/material/Typography";
import PhoneBoxList from '../../Components/PhoneBoxList/PhoneBoxList';

function Home() {
  return (
    <div>
      <Typography variant="h4" sx={{pb: 4}}>Home</Typography>

      <PhoneBoxList />
    </div>
  )
}

export default Home