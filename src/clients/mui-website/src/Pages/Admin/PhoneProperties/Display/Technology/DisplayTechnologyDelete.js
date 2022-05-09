import { Alert, Button, TextField, Typography } from "@mui/material";
import React, { useEffect, useState } from "react";
import { useParams, Link, useNavigate } from "react-router-dom";
import * as DisplayTechnologyService from "../../../../../Services/DisplayTechnologyService";
import { Box } from "@mui/system";

function DisplayTechnologyDelete() {
  const { id } = useParams();
  const navigate = useNavigate();
  const mainUrl = "/admin/display/technology";
  const [displayTechnology, setDisplayTechnology] = useState({ id: "", name: "" });
  const [error, setError] = useState("");

  // Load display technology
  useEffect(() => {
    DisplayTechnologyService.getDisplayTechnology(id)
      .then((res) => {
        if (res.status === 200 && res.data.success) {
          setDisplayTechnology(res.data.data);
        }
      })
      .catch((err) => setError("Cannot find display technology"));
  }, []);

  function handleSubmit(e) {
    DisplayTechnologyService.deleteDisplayTechnology(id);
    navigate(mainUrl);
    navigate(0);
    e.preventDefault();
  }

  return (
    <>
      <Typography variant="h6">Delete Display Technology</Typography>

      {error && (
        <Alert sx={{ mt: 2, mb: 2 }} severity="error">
          {error}
        </Alert>
      )}

      <form onSubmit={handleSubmit}>
        <Box sx={{ mt: 2 }}>
          <input readOnly hidden id="id" name="id" value={id} />

          <Typography variant="body1">
            Are you sure you want to DELETE the following Display Technology?
          </Typography>

          <Typography variant="h4">{displayTechnology.name}</Typography>
        </Box>

        <Box sx={{ mt: 2 }}>
          <Button color="error" variant="contained" type="submit">
            YES, I WANT TO DELETE THE DISPLAY TECHNOLOGY
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
  );
}

export default DisplayTechnologyDelete