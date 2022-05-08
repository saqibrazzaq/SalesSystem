import { Alert, Button, TextField, Typography } from "@mui/material";
import React, { useEffect, useState } from "react";
import { useParams, Link, useNavigate } from "react-router-dom";
import * as BackMaterialService from "../../../../../Services/BackMaterialService";
import { Box } from "@mui/system";

function BackMaterialDelete() {

  const { id } = useParams();
  const navigate = useNavigate();
  const mainUrl = "/admin/body/back-material";
  const [backMaterial, setBackMaterial] = useState({ id: "", name: "" });
  const [error, setError] = useState("");

  // Load back material
  useEffect(() => {
    BackMaterialService.getBackMaterial(id)
      .then((res) => {
        if (res.status === 200 && res.data.success) {
          setBackMaterial(res.data.data);
        }
      })
      .catch((err) => setError("Cannot find Back Material"));
  }, []);

  function handleSubmit(e) {
    BackMaterialService.deleteBackMaterial(id);
    navigate(mainUrl);
    navigate(0);
    e.preventDefault();
  }

  return (
    <>
      <Typography variant="h6">Delete Back Material</Typography>

      {error && (
        <Alert sx={{ mt: 2, mb: 2 }} severity="error">
          {error}
        </Alert>
      )}

      <form onSubmit={handleSubmit}>
        <Box sx={{ mt: 2 }}>
          <input readOnly hidden id="id" name="id" value={id} />

          <Typography variant="body1">
            Are you sure you want to DELETE the following Back Material?
          </Typography>

          <Typography variant="h4">{backMaterial.name}</Typography>
        </Box>

        <Box sx={{ mt: 2 }}>
          <Button color="error" variant="contained" type="submit">
            YES, I WANT TO DELETE THE BACK MATERIAL
          </Button>
          <Button
            component={Link}
            to={mainUrl}
            sx={{ ml: 1, background: "grey" }}
            variant="contained"
          >
            Back
          </Button>
        </Box>
      </form>
    </>
  )
}

export default BackMaterialDelete