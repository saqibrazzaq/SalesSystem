import { Button, TextField, Typography } from "@mui/material";
import React, { useEffect, useState } from "react";
import { useParams, Link, useNavigate } from "react-router-dom";
import * as BrandService from "../../../../../Services/BrandService";
import { Box } from "@mui/system";

function BrandDelete() {
  // Get id from url param
  let { id } = useParams();
  const navigate = useNavigate();
  const brandsUrl = "/admin/general/brand";
  const [brand, setBrand] = useState({ id: "", name: "" });

  // Load brand
  useEffect(() => {
    BrandService.getBrand(id).then((res) => {
      if (res && res.status === 200 && res.data && res.data.success) {
        setBrand(res.data.data);
      }
    });
  }, []);

  function handleSubmit(e) {
    // console.log('Deleting ' + id);
    BrandService.deleteBrand(id);
    navigate(brandsUrl)
    navigate(0)
    e.preventDefault();
  }

  return (
    <>
      <Typography variant="h6">Delete Brand</Typography>

      <form onSubmit={handleSubmit}>
        <Box sx={{ mt: 2 }}>
          <input readOnly hidden id="id" name="id" value={id} />

          <Typography variant="body1">
            Are you sure you want to DELETE the following Brand?
          </Typography>

          <Typography variant="h4">{brand.name}</Typography>
        </Box>

        <Box sx={{ mt: 2 }}>
          <Button color="error" variant="contained" type="submit">
            YES, I WANT TO DELETE THE BRAND
          </Button>
          <Button component={Link} to={brandsUrl} sx={{ml: 1}} variant="contained">Back</Button>
        </Box>
      </form>
    </>
  );
}

export default BrandDelete;
