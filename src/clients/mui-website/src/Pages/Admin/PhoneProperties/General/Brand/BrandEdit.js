import { Alert, Button, TextField, Typography } from "@mui/material";
import React, { useEffect, useState } from "react";
import { useParams, useNavigate } from "react-router-dom";
import { Formik, Field, Form, ErrorMessage, useFormik } from "formik";
import * as Yup from "yup";
import * as BrandService from "../../../../../Services/BrandService";
import { Box } from "@mui/system";

// Formik validation schema
const validationSchema = Yup.object({
  name: Yup.string()
    .max(15, "Must be 15 characters or less")
    .required("Required"),
  position: Yup.number(),
});

function BrandEdit() {
  // Get id from url param
  let { id } = useParams();
  const navigate = useNavigate();
  // Display error messages
  const [error, setError] = useState("");
  // Edit or add new button
  const btnAddUpdate = id ? "Edit Brand" : "Add New Brand";
  let brand = {
    id: null,
    name: "",
    position: 1,
  };

  // Initialize Formik
  const formik = useFormik({
    initialValues: brand,
    validationSchema: validationSchema,
    onSubmit: (values) => {
      if (values.id) {
        editBrand(values);
      } else {
        addBrand(values);
      }
    },
  });

  function editBrand(values) {
    BrandService.editBrand(values)
      .then((res) => {
        // console.log(res);
        navigate("/admin/general/brand");
      })
      .catch((err) => setError("Error creating new Brand"));
  }

  function addBrand(values) {
    BrandService.addBrand(values)
      .then((res) => {
        console.log(res);
        navigate("/admin/general/brand");
      })
      .catch((err) => setError("Error creating new Brand"));
  }

  // Load brand
  useEffect(() => {
    if (id) {
      BrandService.getBrand(id).then((res) => {
        // console.log(res);
        if (res && res.status === 200 && res.data && res.data.success) {
          console.log(res.data.data);
          formik.setValues(res.data.data);
        }
      });
    }
  }, []);
  return (
    <>
      <Typography variant="h6">{btnAddUpdate}</Typography>

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
            {btnAddUpdate}
          </Button>
        </div>
      </Box>
    </>
  );
}

export default BrandEdit;
