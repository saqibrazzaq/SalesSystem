import { Alert, Button, TextField, Typography } from "@mui/material";
import React, { useEffect, useState } from "react";
import { useParams, Link, useNavigate } from "react-router-dom";
import * as CameraTypeService from "../../../../../Services/CameraTypeService";
import { Box } from "@mui/system";

function CameraTypeDelete() {
  const { id } = useParams();
  const navigate = useNavigate();
  const mainUrl = "/admin/camera/type";
  const [cameraType, setCameraType] = useState({ id: "", name: "" });
  const [error, setError] = useState("");

  // Load camera type
  useEffect(() => {
    CameraTypeService.getCameraType(id)
      .then((res) => {
        if (res.status === 200 && res.data.success) {
          setCameraType(res.data.data);
        }
      })
      .catch((err) => setError("Cannot find camera type"));
  }, []);

  function handleSubmit(e) {
    CameraTypeService.deleteCameraType(id);
    navigate(mainUrl);
    navigate(0);
    e.preventDefault();
  }

  return (
    <>
      <Typography variant="h6">Delete Camera Type</Typography>

      {error && (
        <Alert sx={{ mt: 2, mb: 2 }} severity="error">
          {error}
        </Alert>
      )}

      <form onSubmit={handleSubmit}>
        <Box sx={{ mt: 2 }}>
          <input readOnly hidden id="id" name="id" value={id} />

          <Typography variant="body1">
            Are you sure you want to DELETE the following Camera Type?
          </Typography>

          <Typography variant="h4">{cameraType.name}</Typography>
        </Box>

        <Box sx={{ mt: 2 }}>
          <Button color="error" variant="contained" type="submit">
            YES, I WANT TO DELETE THE CAMERA TYPE
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

export default CameraTypeDelete