import { Grid, Typography } from "@mui/material";
import React, { useEffect, useState } from "react";
import PhoneBox from "../PhoneBox/PhoneBox";
import * as PhoneService from '../../Services/PhoneService';

function PhoneBoxList() {
  // Loading true
  const [loading, setLoading] = useState(true);
  // Phone list empty
  const [items, setItems] = useState([]);

  // Get phone list
  useEffect(() => {
    // Loading
    setLoading(true);
    // Get phones
    PhoneService.getAllPhones().then((res) => {
      // Read response
      if (res && res.status === 200 && res.data && res.data.success) {
        // console.log(res.data.data);
        setItems(res.data.data);
        setLoading(false);
      }
    });
  }, []);

  // create list from api response
  const phoneList = items.map((phone) => {
    return <PhoneBox key={phone.id} phone={phone} />;
  });

  return (
    <div>
      <Grid container spacing={2}>
        {loading && <Typography>Loading...</Typography>}
        {!loading && phoneList}
      </Grid>
    </div>
  );
}

export default PhoneBoxList;
