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
import * as SimSizeService from "../../../../../Services/SimSizeService";
import { Box } from "@mui/system";

// Formik validation schema
const validationSchema = Yup.object({
  name: Yup.string()
    .max(15, "Must be 15 characters or less")
    .required("Required"),
  position: Yup.number(),
});

function SimSizeEdit() {
  // Get id
  const { id } = useParams();
  const navigate = useNavigate();
  const [error, setError] = useState("");

  // Button text
  const updateText = id ? "Edit Sim Size" : "Add New Sim Size";

  let simSize = {
    id: "",
    name: "",
    position: 1,
  };
  const mainUrl = "/admin/sim/size";

  // Initialize form
  const formik = useFormik({
    initialValues: simSize,
    validationSchema: validationSchema,
    onSubmit: (values) => {
      if (values.id) {
        editSimSize(values);
      } else {
        addSimSize(values);
      }
    },
  });

  function addSimSize(values) {
    SimSizeService.addSimSize(values)
      .then((res) => {
        navigate(mainUrl);
      })
      .catch((err) => setError("Error creating Sim Size"));
  }

  function editSimSize(values) {
    SimSizeService.editSimSize(values)
      .then((res) => {
        navigate(mainUrl);
      })
      .catch((err) => setError("Cannot edit Sim Size"));
  }

  useEffect(() => {
    // Get sim size
    if (id) {
      SimSizeService.getSimSize(id).then((res) => {
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

export default SimSizeEdit;