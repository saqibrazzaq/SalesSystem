import { Alert, Button, TextField, Typography } from "@mui/material";
import React, { useEffect, useState } from "react";
import { useParams, Link, useNavigate } from "react-router-dom";
import * as FormFactorService from "../../../../../Services/FormFactorService";
import { Box } from "@mui/system";

function FormFactorDelete() {
  const { id } = useParams();
  const navigate = useNavigate();
  const mainUrl = "/admin/body/form-factor";
  const [formFactor, setFormFactor] = useState({ id: "", name: "" });
  const [error, setError] = useState("");

  // Load form factor
  useEffect(() => {
    FormFactorService.getFormFactor(id)
      .then((res) => {
        if (res.status === 200 && res.data.success) {
          setFormFactor(res.data.data);
        }
      })
      .catch((err) => setError("Cannot find Form Factor"));
  }, []);

  function handleSubmit(e) {
    FormFactorService.deleteFormFactor(id);
    navigate(mainUrl);
    navigate(0);
    e.preventDefault();
  }

  return (
    <>
      <Typography variant="h6">Delete Form Factor</Typography>

      {error && (
        <Alert sx={{ mt: 2, mb: 2 }} severity="error">
          {error}
        </Alert>
      )}

      <form onSubmit={handleSubmit}>
        <Box sx={{ mt: 2 }}>
          <input readOnly hidden id="id" name="id" value={id} />

          <Typography variant="body1">
            Are you sure you want to DELETE the following Form Factor?
          </Typography>

          <Typography variant="h4">{formFactor.name}</Typography>
        </Box>

        <Box sx={{ mt: 2 }}>
          <Button color="error" variant="contained" type="submit">
            YES, I WANT TO DELETE THE FORM FACTOR
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

export default FormFactorDelete