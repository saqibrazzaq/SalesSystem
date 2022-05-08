import { Alert, Button, TextField, Typography } from "@mui/material";
import React, { useEffect, useState } from "react";
import {
  useParams,
  useNavigate,
  Link,
  useSearchParams,
} from "react-router-dom";
import { Formik, Field, Form, ErrorMessage, useFormik } from "formik";
import * as Yup from "yup";
import * as OsService from "../../../../../Services/OsService";
import * as OsVersionService from "../../../../../Services/OsVersionService";
import { Box } from "@mui/system";

// Formik validation schema
const validationSchema = Yup.object({
  name: Yup.string()
    .max(15, "Must be 15 characters or less")
    .required("Required"),
  position: Yup.number(),
  osId: Yup.string().required("Required"),
});

function OsVersionEdit() {
  // Get id
  const { id } = useParams();
  const [searchParams] = useSearchParams();
  const osId = searchParams.get("osId");
  const navigate = useNavigate();
  const [error, setError] = useState("");

  // Button text
  const [updateText, setUpdateText] = useState("");

  let osVersion = {
    id: id,
    osId: osId,
    name: "",
    position: 1,
  };

  const [os, setOs] = useState({
    id: "",
    name: "",
  });
  const mainUrl = `/admin/platform/os-version/list/${osId}`;

  // Load os version information
  useEffect(() => {
    setError("");
    OsService.getOS(osId)
      .then((res) => {
        if (res.status === 200 && res.data.success) {
          setOs(res.data.data);
          setUpdateText(
            (id ? " Edit " : "Add New ") + res.data.data.name + " OS"
          );
        } else {
          setError("OS not found");
        }
      })
      .catch((err) => setError("OS not found"));
  }, [id]);

  // Initialize form
  const formik = useFormik({
    initialValues: osVersion,
    validationSchema: validationSchema,
    onSubmit: (values) => {
      if (values.id) {
        editOsVersion(values);
      } else {
        addOsVersion(values);
      }
    },
  });

  function addOsVersion(values) {
    OsVersionService.addOSVersion(values)
      .then((res) => {
        navigate(mainUrl);
      })
      .catch((err) => setError("Error creating new OS Version"));
  }

  function editOsVersion(values) {
    OsVersionService.editOSVersion(values)
      .then((res) => {
        navigate(mainUrl);
      })
      .catch((err) => setError("Cannot edit OS Version"));
  }

  useEffect(() => {
    // Get os version
    if (id) {
      OsVersionService.getOSVersion(id).then((res) => {
        // console.log(res);
        if (res.status === 200 && res.data.success) {
          formik.setValues(res.data.data);
        }
      });
    }
  }, []);

  return (
    <>
      <Typography variant="h6">{updateText}</Typography>

      {error && (
        <Alert sx={{ mt: 2, mb: 2 }} severity="error">
          {error}
        </Alert>
      )}

      <Box
        component="form"
        onSubmit={formik.handleSubmit}
        sx={{
          "& .MuiTextField-root": { m: 1, width: "25ch" },
        }}
      >
        <div>
          <TextField
            fullWidth
            id="name"
            name="name"
            label="Name"
            value={formik.values.name}
            onChange={formik.handleChange}
            error={formik.touched.name && Boolean(formik.errors.name)}
            helperText={formik.touched.name && formik.errors.name}
          />

          <TextField
            fullWidth
            id="position"
            name="position"
            label="Position"
            value={formik.values.position}
            onChange={formik.handleChange}
            error={formik.touched.position && Boolean(formik.errors.position)}
            helperText={formik.touched.position && formik.errors.position}
          />
        </div>

        <div>
          <Button color="primary" variant="contained" type="submit">
            {updateText}
          </Button>
          <Button
            component={Link}
            to={mainUrl}
            sx={{ ml: 1, background: "grey" }}
            variant="contained"
          >
            Back
          </Button>
        </div>
      </Box>
    </>
  );
}

export default OsVersionEdit