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
import * as NetworkBandService from "../../../../../Services/NetworkBandService";
import * as NetworkService from "../../../../../Services/NetworkService";
import { Box } from "@mui/system";

// Formik validation schema
const validationSchema = Yup.object({
  name: Yup.string()
    .max(15, "Must be 15 characters or less")
    .required("Required"),
  position: Yup.number(),
  networkId: Yup.string().required("Required"),
});

function NetworkBandEdit() {
  // Get id
  const { id } = useParams();
  const [searchParams] = useSearchParams();
  const networkId = searchParams.get("networkId");
  const navigate = useNavigate();
  const [error, setError] = useState("");

  // Button text
  const [updateText, setUpdateText] = useState("");

  let band = {
    id: id,
    networkId: networkId,
    name: "",
    position: 1,
  };

  const [network, setNetwork] = useState({
    id: "",
    name: "",
  });
  const mainUrl = `/admin/network/band/list/${networkId}`;

  // Load network information
  useEffect(() => {
    setError("");
    NetworkService.getNetwork(networkId)
      .then((res) => {
        if (res.status === 200 && res.data.success) {
          setNetwork(res.data.data);
          setUpdateText(
            (id ? " Edit " : "Add New ") + res.data.data.name + " Band"
          );
        } else {
          setError("Network not found");
        }
      })
      .catch((err) => setError("Network not found"));
  }, [id]);

  // Initialize form
  const formik = useFormik({
    initialValues: band,
    validationSchema: validationSchema,
    onSubmit: (values) => {
      if (values.id) {
        editBand(values);
      } else {
        addBand(values);
      }
    },
  });

  function addBand(values) {
    NetworkBandService.addBand(values)
      .then((res) => {
        navigate(mainUrl);
      })
      .catch((err) => setError("Error creating new Band"));
  }

  function editBand(values) {
    NetworkBandService.editBand(values)
      .then((res) => {
        navigate(mainUrl);
      })
      .catch((err) => setError("Cannot edit Band"));
  }

  useEffect(() => {
    // Get band
    if (id) {
      NetworkBandService.getBand(id).then((res) => {
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

export default NetworkBandEdit;
